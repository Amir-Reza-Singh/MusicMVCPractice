using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace MusicMVCPractice.Models
{
    public class DBModel
    {
        string connectionString = ConfigurationManager.ConnectionStrings["ConnectionStringName"].ToString();
        
            
        //ARTIST MODEL
        public List<Artist> getArtist()
        {

            

            List<Artist> list = new List<Artist>();


            string queryString =
           "SELECT ArtistId, Name FROM Artist ORDER BY Name; ";
            using (SqlConnection connection =
            new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        var read = new Artist { ArtistId = Convert.ToInt32(reader[0]), Name = reader[1].ToString() };
                        list.Add(read);
                    }
                    reader.Close();

                }

                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }


            }
            return list;
        }

        public void addArtist(string name)
        {


            string query = "INSERT INTO Artist (name) " +
                   "VALUES (@name) ";

            using (SqlConnection connection =
            new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@name", name);

                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();

                }

                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }


            }

        }



        //ALBUM MODEL
        public List<Album> getAlbum()
        {



            List<Album> list = new List<Album>();


            string queryString =
           "SELECT Album.Title, Artist.Name FROM Album INNER JOIN Artist ON Album.ArtistId = Artist.ArtistId ORDER BY Album.Title; ";
            using (SqlConnection connection =
            new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        var read = new Album { Title = reader[0].ToString(), Name = reader[1].ToString()};
                        list.Add(read);
                    }
                    reader.Close();

                }

                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }


            }
            return list;
        }

        public void addAlbum(string name, string title)
        {


            string query = "INSERT INTO Album (Title) " +
                   "VALUES (@title) ";
            string queryMatch = "SELECT Artist.Name FROM Artist WHERE Artist.Name = @name";

            using (SqlConnection connection =
            new SqlConnection(connectionString))
            {
                SqlCommand match = new SqlCommand(queryMatch, connection);
                try
                {
                    connection.Open();
                    SqlDataReader reader = match.ExecuteReader();
                    if (reader.Read())
                    {
                        SqlCommand command = new SqlCommand(query, connection);
                        command.Parameters.AddWithValue("@title", title);


                        try
                        {
                            connection.Open();
                            command.ExecuteNonQuery();

                        }

                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                    } else {
                        reader.Close();
                    }
                    

                }

                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                


            }

        }
    }
}