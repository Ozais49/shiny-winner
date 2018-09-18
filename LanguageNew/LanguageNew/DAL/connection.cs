using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace LanguageNew.DAL
{
    public class connection
    {
        public static string ConnectionString
        {
            get
            {
                return ConfigurationManager.ConnectionStrings["LanguageExam"].ConnectionString;
                //ConnectionStringSettings settings =
                //    ConfigurationManager.ConnectionStrings["LanguageExam"];
                //string connectString = settings.ConnectionString;
                //SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder(connectString);
                //return builder.ToString();
            }
        }






    }
}