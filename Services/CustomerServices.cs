using Points_System.Class;
using Points_System.Models;
using System.Data;
using MySql.Data.MySqlClient;

namespace Points_System.Services
{
    public class CustomerServices
    {
        private readonly AppDb _constring;
        public IConfiguration Configuration;

        public CustomerServices(AppDb constring, IConfiguration configuration)
        {
            _constring = constring;
            Configuration = configuration;
        }

        public async Task<List<customers>> Customers()
        {
            List<customers> _customer = new List<customers>();
            using (var con = new MySqlConnection(_constring.GetConnection()))
            {
                try
                {
                    await con.OpenAsync().ConfigureAwait(false);
                    var com = new MySqlCommand("ViewCustomer", con)
                    {
                        CommandType = CommandType.StoredProcedure,
                    };
                    var rdr = await com.ExecuteReaderAsync().ConfigureAwait(false);
                    while (await rdr.ReadAsync().ConfigureAwait(false))
                    {
                        _customer.Add(new customers
                        {
                            customerID = rdr["customerID"].ToString(),
                            fname = rdr["fname"].ToString(),
                            mname = rdr["mname"].ToString(),
                            lname = rdr["lname"].ToString(),
                            address = rdr["address"].ToString(),
                            contact = rdr["contact"].ToString(),
                            fullname = rdr["fullname"].ToString(),
                            points = Convert.ToDecimal( rdr["points"])
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
            return _customer;
        }

        public async Task<List<customers>> SearchCustomer(string search)
        {
            List<customers> _customer = new List<customers>();
            using (var con = new MySqlConnection(_constring.GetConnection()))
            {
                try
                {
                    await con.OpenAsync().ConfigureAwait(false);
                    var com = new MySqlCommand("SearchCustomer", con)
                    {
                        CommandType = CommandType.StoredProcedure,
                    };
                    com.Parameters.Clear();
                    com.Parameters.AddWithValue("search", search);
                    com.Parameters.AddWithValue("@searchWildcard", $"{search}%");
                    var rdr = await com.ExecuteReaderAsync().ConfigureAwait(false);
                    while (await rdr.ReadAsync().ConfigureAwait(false))
                    {
                        _customer.Add(new customers
                        {
                            customerID = rdr["customerID"].ToString(),
                            fname = rdr["fname"].ToString(),
                            mname = rdr["mname"].ToString(),
                            lname = rdr["lname"].ToString(),
                            address = rdr["address"].ToString(),
                            contact = rdr["contact"].ToString(),
                            fullname = rdr["fullname"].ToString(),
                            points = Convert.ToDecimal(rdr["points"])
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
            return _customer;
        }

        public async Task<int> AddCustomer(customers cus)
        {
            using (var con = new MySqlConnection(_constring.GetConnection()))
            {
                try
                {
                    await con.OpenAsync().ConfigureAwait(false);
                    var com = new MySqlCommand("AddCustomer", con)
                    {
                        CommandType = CommandType.StoredProcedure,
                    };
                    com.Parameters.AddWithValue("_customerID", cus.customerID);
                    com.Parameters.AddWithValue("_fname", cus.fname);
                    com.Parameters.AddWithValue("_mname", cus.mname);
                    com.Parameters.AddWithValue("_lname", cus.lname);
                    com.Parameters.AddWithValue("_address", cus.address);
                    com.Parameters.AddWithValue("_contact", cus.contact);
                    com.Parameters.AddWithValue("_points", cus.points);
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

        public async Task<int> UpdateCustomer(customers cus)
        {
            using (var con = new MySqlConnection(_constring.GetConnection()))
            {
                try
                {
                    await con.OpenAsync().ConfigureAwait(false);
                    var com = new MySqlCommand("UpdateCustomer", con)
                    {
                        CommandType = CommandType.StoredProcedure,
                    };
                    com.Parameters.AddWithValue("_customerID", cus.customerID);
                    com.Parameters.AddWithValue("_fname", cus.fname);
                    com.Parameters.AddWithValue("_mname", cus.mname);
                    com.Parameters.AddWithValue("_lname", cus.lname);
                    com.Parameters.AddWithValue("_address", cus.address);
                    com.Parameters.AddWithValue("_contact", cus.contact);
                    com.Parameters.AddWithValue("_points", cus.points);
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
