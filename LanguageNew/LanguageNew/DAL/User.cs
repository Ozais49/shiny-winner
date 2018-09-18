using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LanguageNew.Repo;
using LanguageNew.Models;
using System.Data.SqlClient;
using System.Data;
using NLog;

namespace LanguageNew.DAL
{
    public class User : IUser
    {
        public bool Add(UserTable entity)
        {
            throw new NotImplementedException();
        }

        public bool Delete(UserTable entity)
        {
            throw new NotImplementedException();
        }
        public bool Update(UserTable entity)
        {
            throw new NotImplementedException();
        }

        public UserTable Get(string id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<UserTable> GetAll()
        {
            throw new NotImplementedException();
        }

        public void insertLoginSuccess(string Username, string UserAgent)
        {
           
            NlogerConfig config = new NlogerConfig();
            Logger logger = LogManager.GetLogger("User");
            SqlConnection conn = new SqlConnection(connection.ConnectionString);
            try
            {
                using (conn)
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = conn;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "s_LoginSuccess";
                        cmd.Parameters.AddWithValue("@Username", Username);
                        cmd.Parameters.AddWithValue("@userAgent", UserAgent);
                        if (conn.State != ConnectionState.Open)
                            conn.Open();
                        cmd.ExecuteNonQuery();
                        if (conn.State != ConnectionState.Closed)
                            conn.Close();

                    }
                }

            }
            catch (Exception ex)
            {
                if (conn.State != ConnectionState.Closed)
                    conn.Close();
                logger.Error(ex, "Error occured when inserting LoginSucess");
            }
        }

        public int validateUser(UserTable model)
        {
            int value=99;
            NlogerConfig config = new NlogerConfig();
            Logger logger = LogManager.GetLogger("User");
            SqlConnection conn = new SqlConnection(connection.ConnectionString);
            try
            {
                using (conn)
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = conn;
                        cmd.CommandType = CommandType.Text;
                        cmd.CommandText = "Select dbo.f_ValidateUser(@Username,@Password)";
                        cmd.Parameters.AddWithValue("@Username", model.Username);
                        cmd.Parameters.AddWithValue("@Password", model.Password);
                        if (conn.State != ConnectionState.Open)
                            conn.Open();
                        value = (int)cmd.ExecuteScalar();
                        if (conn.State != ConnectionState.Closed)
                            conn.Close();

                    }
                }
               
            }
            catch (Exception ex)
            {
                if (conn.State != ConnectionState.Closed)
                    conn.Close();
                logger.Error(ex, "An error occured when validating user.");
                throw;
               
            }

            return value;
        }
    }
}