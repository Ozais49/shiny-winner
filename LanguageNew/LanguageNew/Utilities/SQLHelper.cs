using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace LanguageNew.Utilities
{
    public static class SQLHelper
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="connection"></param>
        /// <param name="CommandText"></param>
        /// <param name="CommandType"></param>
        /// <param name="Timeout"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public static DataTable ExecuteQuery(this SqlConnection connection, string CommandText,CommandType CommandType=CommandType.Text,int Timeout=60,params string[] parameters)
        {
            DataTable data= new DataTable();
           

            var command = PrepareCommand(connection, CommandText, CommandType, Timeout, parameters);
            if(command!=null)
            {
                using (command)
                {
                    if (connection.State != ConnectionState.Open)
                        connection.Open();
                    //command.ExecuteNonQuery();
                    using (SqlDataAdapter da = new SqlDataAdapter(command))
                    {
                        da.Fill(data);
                    }

                        
                }
            }
            return data;
        }
        //public static DataTable ExecuteQuery(this SqlConnection connection, string CommandText, CommandType CommandType = CommandType.Text, int Timeout = 60)
        //{
        //    DataTable data = new DataTable();


        //    var command = PrepareCommand(connection, CommandText, CommandType, Timeout);
        //    if (command != null)
        //    {
        //        using (command)
        //        {
        //            if (connection.State != ConnectionState.Open)
        //                connection.Open();
        //            command.ExecuteNonQuery();
        //            using (SqlDataAdapter da = new SqlDataAdapter(command))
        //            {
        //                da.Fill(data);
        //            }

        //        }
        //    }
        //    return data;
        //}
        private static SqlCommand PrepareCommand(SqlConnection connection, string CommandText, CommandType CommandType, int Timeout, params string[] parameters)
        {
            SqlCommand cmd = new SqlCommand();
            try
            {
                cmd.Connection = connection;
                cmd.CommandText = CommandText;
                cmd.CommandType = CommandType;
                cmd.CommandTimeout = Timeout;
                if(parameters!=null)
                    cmd.Parameters.AddRange(parameters);
                SqlParameter p = new SqlParameter();
                return cmd;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}