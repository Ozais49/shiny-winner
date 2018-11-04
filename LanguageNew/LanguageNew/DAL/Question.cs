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
    public class Question : IQuestion
    {
        public bool Add(Questions entity)
        {
            SqlConnection con = new SqlConnection(connection.ConnectionString);
            int i = 0;
            try
            {
                using (con)
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = con;
                        cmd.CommandType = CommandType.Text;
                        cmd.CommandText = @"INSERT INTO Questions
                                            ( Question , Option1,Option2 , Option3 , Option4 , Answer , Status , Category , Type ,Image )
                                            VALUES
                                            (@Question,@Option1,@Option2,@Option3,@Option4,@Answer,@Status,@Category,@Type,@Image)";
                        cmd.Parameters.AddWithValue("@Question", entity.Question);
                        cmd.Parameters.AddWithValue("@Option1", entity.Option1);
                        cmd.Parameters.AddWithValue("@Option2", entity.Option2);
                        cmd.Parameters.AddWithValue("@Option3", entity.Option3);
                        cmd.Parameters.AddWithValue("@Option4", entity.Option4);
                        cmd.Parameters.AddWithValue("@Answer", entity.Answer);
                        cmd.Parameters.AddWithValue("@Status", entity.Status);
                        cmd.Parameters.AddWithValue("@Category", entity.Category);
                        cmd.Parameters.AddWithValue("@Type", entity.Type);
                        cmd.Parameters.AddWithValue("@Image", entity.Image);
                        if (con.State != ConnectionState.Open)
                            con.Open();

                        i = cmd.ExecuteNonQuery();

                        if (con.State != ConnectionState.Closed)
                            con.Close();

                        if (i == 1)
                            return true;
                        else
                            return false;

                    }
                }
            }
            catch (Exception ex)
            {
                if (con.State != ConnectionState.Closed)
                    con.Close();
                throw ex;
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

                using (con)
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

        public string GetImage(int id)
        {
            throw new NotImplementedException();
        }

        public bool Update(Questions Entity)
        {
            SqlConnection con = new SqlConnection(connection.ConnectionString);
            int i = 0;
            try
            {
                using (con)
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = con;
                        cmd.CommandType = CommandType.Text;
                        cmd.CommandText = @"UPDATE Questions
                                                SET 
                                                Question =@Question ,
                                                    Option1=@Option1,
                                                    Option2=@Option2,
                                                    Option3=@Option3,
                                                    Option4=@Option4,
                                                    Answer=@Answer ,
                                                    Status=@Status ,
                                                    Category=@Category ,
                                                    Type=@Type ,
                                                    Image =@Image WHERE Id=@Id";
                        cmd.Parameters.AddWithValue("@Id", Entity.Id);
                        cmd.Parameters.AddWithValue("@Question", Entity.Question);
                        cmd.Parameters.AddWithValue("@Option1", Entity.Option1);
                        cmd.Parameters.AddWithValue("@Option2", Entity.Option2);
                        cmd.Parameters.AddWithValue("@Option3", Entity.Option3);
                        cmd.Parameters.AddWithValue("@Option4", Entity.Option4);
                        cmd.Parameters.AddWithValue("@Answer", Entity.Answer);
                        cmd.Parameters.AddWithValue("@Status", Entity.Status);
                        cmd.Parameters.AddWithValue("@Category", Entity.Category);
                        cmd.Parameters.AddWithValue("@Type", Entity.Type);
                        cmd.Parameters.AddWithValue("@Image", Entity.Image);
                        if (con.State != ConnectionState.Open)
                            con.Open();

                        i = cmd.ExecuteNonQuery();

                        if (con.State != ConnectionState.Closed)
                            con.Close();

                        if (i == 1)
                            return true;
                        else
                            return false;

                    }
                }
            }
            catch (Exception ex)
            {
                if (con.State != ConnectionState.Closed)
                    con.Close();
                throw ex;
            }
        }
    }
}