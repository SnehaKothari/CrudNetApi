using LinqToDB;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using user.Web.Data;
using user.Web.Models;


namespace user.Web.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly string _databaseConnectionString;
        private readonly string _databaseSchema;

        public UserRepository(string ConnectionString, string databaseSchema)
        {
            _databaseConnectionString = ConnectionString;
            _databaseSchema = databaseSchema;
        }
       

        #region Get All Keys

        public async Task<IEnumerable<Users>> GetAllKeys()
        {

            string strQueryGetAllKeys = "SELECT * from " + _databaseSchema + ".userdata";
            List<Users> modelList = new List<Users>();
            DataTable dt = new DataTable();
            try
            {
                await using (Npgsql.NpgsqlConnection con = new Npgsql.NpgsqlConnection(_databaseConnectionString))
                {
                    await using (Npgsql.NpgsqlCommand cmd = new Npgsql.NpgsqlCommand(strQueryGetAllKeys, con))
                    {
                        await con.OpenAsync().ConfigureAwait(false);
                        NpgsqlDataAdapter da = new NpgsqlDataAdapter(cmd);
                        da.Fill(dt);
                        await con.CloseAsync().ConfigureAwait(false);
                    }

                    if (dt.Rows.Count > 0)
                    {
                        foreach (DataRow row in dt.Rows)
                        {
                            Users users = new Users();
                            users.Id = Convert.ToInt32(row["Id"]);
                            users.Name = Convert.ToString(row["Name"]);
                            users.Username = Convert.ToString(row["Username"]);
                            users.Email = Convert.ToString(row["Email"]);
                            modelList.Add(users);
                        }
                    }
                }
            }
            catch (Npgsql.NpgsqlException ex)
            {
                throw new Exception($"Failed to GetAllKeys {ex}");
            }
            return modelList;

        }
        #endregion


      
        #region Get Key
        public async Task<IEnumerable<Users>> GetKey(int Id)
        {

            string strQueryGetAllKeys = "SELECT * from " + _databaseSchema + ".userdata where Id='"+Id+"'";
            List<Users> modelList = new List<Users>();
            DataTable dt = new DataTable();
            try
            {
                await using (Npgsql.NpgsqlConnection con = new Npgsql.NpgsqlConnection(_databaseConnectionString))
                {
                    await using (Npgsql.NpgsqlCommand cmd = new Npgsql.NpgsqlCommand(strQueryGetAllKeys, con))
                    {
                        await con.OpenAsync().ConfigureAwait(false);
                        NpgsqlDataAdapter da = new NpgsqlDataAdapter(cmd);
                        da.Fill(dt);
                        await con.CloseAsync().ConfigureAwait(false);
                    }

                    if (dt.Rows.Count > 0)
                    {
                        foreach (DataRow row in dt.Rows)
                        {
                            Users users = new Users();

                            users.Id = Convert.ToInt32(row["Id"]);
                            users.Name = Convert.ToString(row["Name"]);
                            users.Username = Convert.ToString(row["Username"]);
                            users.Email = Convert.ToString(row["Email"]);
                            modelList.Add(users);
                        }
                    }
                }
            }
            catch (Npgsql.NpgsqlException ex)
            {
                throw new Exception($"Failed to GetKey {ex}");
            }
            return modelList;

        }
        #endregion

        #region Insert Keys
        public async Task<bool> InsertKeys(Users users)
        {
            string strQueryGetAllKeys = "insert into public.userdata(Name,Username,Email) values(@Name,@Username,@Email)";
            List<Users> modelList = new List<Users>();
            DataTable dt = new DataTable();
            try
            {
                await using (Npgsql.NpgsqlConnection con = new Npgsql.NpgsqlConnection(_databaseConnectionString))
                {
                    await using (Npgsql.NpgsqlCommand cmd = new Npgsql.NpgsqlCommand(strQueryGetAllKeys, con))
                    {
                        await con.OpenAsync().ConfigureAwait(false);
                       
                        cmd.Parameters.AddWithValue("@Name", users.Name);
                        cmd.Parameters.AddWithValue("@Username", users.Username);
                        cmd.Parameters.AddWithValue("@Email", users.Email);
                        await cmd.ExecuteNonQueryAsync().ConfigureAwait(false);
                        await con.CloseAsync().ConfigureAwait(false);
                    }

                    if (dt.Rows.Count > 0)
                    {
                        foreach (DataRow row in dt.Rows)
                        {
                            Users user = new Users();
                            users.Name = Convert.ToString(row["Name"]);
                            users.Username = Convert.ToString(row["Username"]);
                            users.Email = Convert.ToString(row["Email"]);
                            modelList.Add(user);
                        }
                    }
                }
            }
            catch (Npgsql.NpgsqlException ex)
            {
                throw new Exception($"Failed to InsertKey {ex}");
            }
            return true;
        }
        #endregion

        #region Update Keys
       public async Task<bool> UpdateKeys(int Id, string Name, string Username, string Email)
        {
            string strQueryUpdateKeys = "UPDATE " + _databaseSchema + ".userdata set Name='" + Name + "', Username='" + Username + "', Email='" + Email + "'" + "where Id='" + Id + "'";
            List<Users> modelList = new List<Users>();
            DataTable dt = new DataTable();
            try
            {
                await using (Npgsql.NpgsqlConnection con = new Npgsql.NpgsqlConnection(_databaseConnectionString))
                {
                    await using (Npgsql.NpgsqlCommand cmd = new Npgsql.NpgsqlCommand(strQueryUpdateKeys, con))
                    {
                        await con.OpenAsync().ConfigureAwait(false);
                        NpgsqlDataAdapter da = new NpgsqlDataAdapter(cmd);
                        //NpgsqlDataReader da;
                        // cmd.Parameters.AddWithValue("@Name", Name);
                        //cmd.Parameters.AddWithValue("@Email", Email);
                        //cmd.Parameters.AddWithValue("@Id", Id);
                        //da = cmd.ExecuteReader();
                        //dt.Load(da);
                        da.Fill(dt);
                       await con.CloseAsync().ConfigureAwait(false);
                    }

                    if (dt.Rows.Count > 0)
                    {
                        foreach (DataRow row in dt.Rows)
                        {
                            Users users = new Users();
                            users.Username = Convert.ToString(row["Username"]);
                            users.Email = Convert.ToString(row["Email"]);
                            modelList.Add(users);
                        }
                    }
                }
            }
            catch (Npgsql.NpgsqlException ex)
            {
                throw new Exception($"Failed to UpdateKey {ex}");
            }
            return true;
        }
     
/*
        public async Task<Users> UpdateKeys(Users users)
        {
            var result=await _context.users.FirstOrDefaultAsync(e=>e.Id==users.Id);
            if (result != null)
            {
                result.Name = users.Name;
                result.Email = users.Email;

                await _context.SaveChangesAsync();

                return result;
            }
            return null;
        }*/

        #endregion



        #region Delete All Key
        public async Task<bool> DeleteAllKeys()
        {
            int result = 0;
            string strQueryDeleteAllKeys = "Delete  from " + _databaseSchema + ".userdata ";
           
            try
            {
                await using (Npgsql.NpgsqlConnection con = new Npgsql.NpgsqlConnection(_databaseConnectionString))
                {
                    await using (Npgsql.NpgsqlCommand cmd = new Npgsql.NpgsqlCommand(strQueryDeleteAllKeys, con))
                    {
                        await con.OpenAsync().ConfigureAwait(false);
                        result = await cmd.ExecuteNonQueryAsync().ConfigureAwait(false);
                        await con.CloseAsync().ConfigureAwait(false);
                    }

                    if (result > 0)
                    {
                        return true;
                    }
                }
            }
            catch (Npgsql.NpgsqlException ex)
            {
                throw new Exception($"Failed to DeleteAllKeys {ex}");
            }
            return false;

        }
        #endregion

        #region Delete Key
        public async Task<bool> DeleteKey(int Id)
        {
            int result = 0;
            string strQueryGetAllKeys = "Delete from " + _databaseSchema + ".userdata where Id='" + Id + "'";
           
            try
            {
                await using (Npgsql.NpgsqlConnection con = new Npgsql.NpgsqlConnection(_databaseConnectionString))
                {
                    await using (Npgsql.NpgsqlCommand cmd = new Npgsql.NpgsqlCommand(strQueryGetAllKeys, con))
                    {
                        await con.OpenAsync().ConfigureAwait(false);
                        // NpgsqlDataAdapter da = new NpgsqlDataAdapter(cmd);
                        cmd.Parameters.AddWithValue("Id",
                            NpgsqlTypes.NpgsqlDbType.Integer).NpgsqlValue = Id;
                        result = await cmd.ExecuteNonQueryAsync().ConfigureAwait(false);
                        await con.CloseAsync().ConfigureAwait(false);
                    }

                    if (result > 0)
                    {
                        return true;
                    }
                }
            }
            catch (Npgsql.NpgsqlException ex)
            {
                throw new Exception($"Failed to GetKey {ex}");
            }
            return false;

        }
        #endregion


    }
}
