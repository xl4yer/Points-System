using MySql.Data.MySqlClient;
using Points_System.Class;
using Points_System.Models;
using System.Data;

namespace Points_System.Services
{
    public class OrderServices
    {
        private readonly AppDb _constring;
        public IConfiguration Configuration;

        public OrderServices(AppDb constring, IConfiguration configuration)
        {
            _constring = constring;
            Configuration = configuration;
        }

        public async Task<List<orders>> Orders()
        {
            List<orders> _order = new List<orders>();
            using (var con = new MySqlConnection(_constring.GetConnection()))
            {
                try
                {
                    await con.OpenAsync().ConfigureAwait(false);
                    var com = new MySqlCommand("ViewOrders", con)
                    {
                        CommandType = CommandType.StoredProcedure,
                    };
                    var rdr = await com.ExecuteReaderAsync().ConfigureAwait(false);
                    while (await rdr.ReadAsync().ConfigureAwait(false))
                    {
                        _order.Add(new orders
                        {
                            orderID = rdr["orderID"].ToString(),
                            date = Convert.ToDateTime(rdr["date"]),
                            photo = (byte[])rdr["photo"],
                            fullname = rdr["fullname"].ToString(),
                            itemname = rdr["itemname"].ToString(),
                            price = Convert.ToDecimal(rdr["price"]),
                            discount = Convert.ToDecimal(rdr["discount"]),
                            total = Convert.ToDecimal(rdr["total"]),
                            points = Convert.ToDecimal(rdr["points"]),
                        });
                    }
                    await rdr.CloseAsync().ConfigureAwait(false);
                }
                catch (Exception ex)
                {
                    // Handle the exception here
                }
                finally
                {
                    await con.CloseAsync().ConfigureAwait(false);
                }
            }
            return _order;
        }

        public async Task<List<orders>> SearchOrder(string search)
        {
            List<orders> _order = new List<orders>();
            using (var con = new MySqlConnection(_constring.GetConnection()))
            {
                try
                {
                    await con.OpenAsync().ConfigureAwait(false);
                    var com = new MySqlCommand("SearchOrder", con)
                    {
                        CommandType = CommandType.StoredProcedure,
                    };
                    com.Parameters.Clear();
                    com.Parameters.AddWithValue("search", search);
                    com.Parameters.AddWithValue("@searchWildcard", $"{search}%");
                    var rdr = await com.ExecuteReaderAsync().ConfigureAwait(false);
                    while (await rdr.ReadAsync().ConfigureAwait(false))
                    {
                        _order.Add(new orders
                        {
                           
                            date = Convert.ToDateTime(rdr["date"]),
                            photo = (byte[])rdr["photo"],
                            fullname = rdr["fullname"].ToString(),
                            itemname = rdr["itemname"].ToString(),
                            price = Convert.ToDecimal(rdr["price"]),
                            discount = Convert.ToDecimal(rdr["discount"]),
                            total = Convert.ToDecimal(rdr["total"]),
                            points = Convert.ToDecimal(rdr["points"]),
                        });
                    }
                    await rdr.CloseAsync().ConfigureAwait(false);
                }
                catch (Exception ex)
                {
                    // Handle the exception here
                }
                finally
                {
                    await con.CloseAsync().ConfigureAwait(false);
                }
            }
            return _order;
        }

        public async Task<int> AddOrder(order2 _order)
        {
            using (var con = new MySqlConnection(_constring.GetConnection()))
            {
                try
                {
                    await con.OpenAsync().ConfigureAwait(false);
                    var com = new MySqlCommand("AddOrder", con)
                    {
                        CommandType = CommandType.StoredProcedure,
                    };
                    com.Parameters.AddWithValue("_date", _order.date);
                    com.Parameters.AddWithValue("_orderID", _order.orderID);
                    com.Parameters.AddWithValue("_customerID", _order.customerID);
                    com.Parameters.AddWithValue("_itemID", _order.itemID);
                    com.Parameters.AddWithValue("_discount", _order.discount);
                    com.Parameters.AddWithValue("_total", _order.total);
                    com.Parameters.AddWithValue("_points", _order.points);
                    return await com.ExecuteNonQueryAsync().ConfigureAwait(false);
                }
                catch (Exception ex)
                {
                    // Handle the exception here
                }
                finally
                {
                    await con.CloseAsync().ConfigureAwait(false);
                }
            }
            return 0;
        }

        public async Task<int> AddOrder2(order2 _order)
        {
            using (var con = new MySqlConnection(_constring.GetConnection()))
            {
                try
                {
                    await con.OpenAsync().ConfigureAwait(false);
                    var com = new MySqlCommand("AddOrder2", con)
                    {
                        CommandType = CommandType.StoredProcedure,
                    };
                    com.Parameters.AddWithValue("_date", _order.date);
                    com.Parameters.AddWithValue("_orderID", _order.orderID);
                    com.Parameters.AddWithValue("_customerID", _order.customerID);
                    com.Parameters.AddWithValue("_itemID", _order.itemID);
                    com.Parameters.AddWithValue("_discount", _order.discount);
                    com.Parameters.AddWithValue("_total", _order.total);
                    com.Parameters.AddWithValue("_points", _order.points);
                    return await com.ExecuteNonQueryAsync().ConfigureAwait(false);
                }
                catch (Exception ex)
                {
                    // Handle the exception here
                }
                finally
                {
                    await con.CloseAsync().ConfigureAwait(false);
                }
            }
            return 0;
        }
    }
}
