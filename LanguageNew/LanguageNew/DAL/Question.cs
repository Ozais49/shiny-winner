using LanguageNew.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LanguageNew.Repo;
using System.Data.SqlClient;
using LanguageNew.Utilities;
using System.Data;
using NLog;

namespace LanguageNew.DAL
{
    public class Question : IRepo<Questions>
    {
        public bool Add(Questions entity)
        {
            SqlConnection con = new SqlConnection(connection.ConnectionString);
           
            try
            {

                using (con)
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = con;
                        cmd.CommandType = CommandType.Text;
                        cmd.CommandText = @"INSERT INTO Questions
                                            ( Question , Option1,Option2 , Option3 , Option4 , Answer , Status , Category , Type  )
                                            VALUES
                                            (@Question,@Option1,@Option2,@Option3,@Option4,@Answer,@Status,@Category,@Type)
";
                      
                        if (con.State != ConnectionState.Open)
                            con.Open();
                      
                       
                        if (con.State != ConnectionState.Closed)
                            con.Close();

                    }
                }
                return false;
            }
            catch (Exception ex)
            {
                if (con.State != ConnectionState.Closed)
                    con.Close();

                return false;

            }
        }

        public bool Delete(Questions entity)
        {
            throw new NotImplementedException();
        }

        public Questions Get(string id)
        {
            Questions question = new Questions();
            SqlConnection con = new SqlConnection(connection.ConnectionString);
            DataTable data = new DataTable();
            try
            {

                using ( con )
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = con;
                        cmd.CommandType = CommandType.Text;
                        cmd.CommandText = "Select * from Question where Id=@Id";
                        cmd.Parameters.AddWithValue("@Id", id);
                        if (con.State != ConnectionState.Open)
                            con.Open();
                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            da.Fill(data);
                        }
                        question = data.ToSingle<Questions>();
                        if (con.State != ConnectionState.Closed)
                            con.Close();

                    }
                }
                return question;
            }
            catch (Exception ex)
            {
                if (con.State != ConnectionState.Closed)
                    con.Close();

                return question;

            }
        }

        public IEnumerable<Questions> GetAll()
        {
            List<Questions> QuestionList = new List<Questions>();
            NlogerConfig config = new NlogerConfig();
            DataTable data = new DataTable();
            Logger logger = LogManager.GetLogger("Question");
            SqlConnection con = new SqlConnection(connection.ConnectionString);
            try
            {
                using (con)
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = con;
                        cmd.CommandType = CommandType.Text;
                        cmd.CommandText = "Select * from Question";
                        if (con.State != ConnectionState.Open)
                            con.Open();
                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            da.Fill(data);
                        }
                        QuestionList = data.ToList<Questions>();
                        if (con.State != ConnectionState.Closed)
                            con.Close();

                    }
                }
                return QuestionList;
            }
            catch (Exception ex)
            {
                if (con.State != ConnectionState.Closed)
                    con.Close();
                logger.Error(ex, "An error occured fetching Questions.");
                return QuestionList;
            }
        }

        public bool Update(Questions Entity)
        {
            throw new NotImplementedException();
        }
    }
}