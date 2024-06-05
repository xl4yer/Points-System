using MySql.Data.MySqlClient;
using Points_System.Class;
using Points_System.Models;
using System.Data;

namespace Points_System.Services
{
    public class ItemServices
    {
        private readonly AppDb _constring;
        public IConfiguration Configuration;

        public ItemServices(AppDb constring, IConfiguration configuration)
        {
            _constring = constring;
            Configuration = configuration;
        }

        public async Task<List<items>> Items()
        {
            List<items> _item = new List<items>();
            using (var con = new MySqlConnection(_constring.GetConnection()))
            {
                try
                {
                    await con.OpenAsync().ConfigureAwait(false);
                    var com = new MySqlCommand("ViewItems", con)
                    {
                        CommandType = CommandType.StoredProcedure,
                    };
                    var rdr = await com.ExecuteReaderAsync().ConfigureAwait(false);
                    while (await rdr.ReadAsync().ConfigureAwait(false))
                    {
                        _item.Add(new items
                        {
                            itemID = rdr["itemID"].ToString(),
                            photo = (byte[])rdr["photo"],
                            itemname = rdr["itemname"].ToString(),
                            price = Convert.ToDecimal( rdr["price"]),
                            status = rdr["status"].ToString()
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
            return _item;
        }

        public async Task<List<items>> SearchItems(string search)
        {
            List<items> _item = new List<items>();
            using (var con = new MySqlConnection(_constring.GetConnection()))
            {
                try
                {
                    await con.OpenAsync().ConfigureAwait(false);
                    var com = new MySqlCommand("SearchItems", con)
                    {
                        CommandType = CommandType.StoredProcedure,
                    };
                    com.Parameters.Clear();
                    com.Parameters.AddWithValue("search", search);
                    com.Parameters.AddWithValue("@searchWildcard", $"{search}%");
                    var rdr = await com.ExecuteReaderAsync().ConfigureAwait(false);
                    while (await rdr.ReadAsync().ConfigureAwait(false))
                    {
                        _item.Add(new items
                        {
                            itemID = rdr["itemID"].ToString(),
                            photo = (byte[])rdr["photo"],
                            itemname = rdr["itemname"].ToString(),
                            price = Convert.ToDecimal(rdr["price"]),
                            status = rdr["status"].ToString()
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
            return _item;
        }

        public async Task<int> AddItems(items i)
        {
            using (var con = new MySqlConnection(_constring.GetConnection()))
            {
                try
                {
                    await con.OpenAsync().ConfigureAwait(false);
                    var com = new MySqlCommand("AddItems", con)
                    {
                        CommandType = CommandType.StoredProcedure,
                    };
                    com.Parameters.AddWithValue("_itemID", i.itemID);
                    com.Parameters.AddWithValue("_photo", i.photo);
                    com.Parameters.AddWithValue("_itemname", i.itemname);
                    com.Parameters.AddWithValue("_price", i.price);
                    com.Parameters.AddWithValue("_status", i.status);
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

        public async Task<int> UpdateItems(items i)
        {
            using (var con = new MySqlConnection(_constring.GetConnection()))
            {
                try
                {
                    await con.OpenAsync().ConfigureAwait(false);
                    var com = new MySqlCommand("UpdateItems", con)
                    {
                        CommandType = CommandType.StoredProcedure,
                    };
                    com.Parameters.AddWithValue("_itemID", i.itemID);
                    com.Parameters.AddWithValue("_photo", i.photo);
                    com.Parameters.AddWithValue("_itemname", i.itemname);
                    com.Parameters.AddWithValue("_price", i.price);
                    com.Parameters.AddWithValue("_status", i.status);
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
