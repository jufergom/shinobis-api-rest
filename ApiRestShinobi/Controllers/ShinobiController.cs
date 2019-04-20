using ApiRestShinobi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MySql.Data.MySqlClient;

namespace ApiRestShinobi.Controllers
{
    public class ShinobiController : ApiController
    {
        string connectionString = "SERVER=localhost;DATABASE=ninjas;UID=root;PASSWORD=1234;";
        // GET: api/Shinobi
        public List<Shinobi> Get()
        {
            List<Shinobi> shinobis = new List<Shinobi>();
            try
            {
                MySqlConnection conn = new MySqlConnection(connectionString);
                conn.Open();
                MySqlDataReader reader;
                MySqlCommand cmd = new MySqlCommand("select * from shinobis", conn);
                reader = cmd.ExecuteReader();
                
                while (reader.Read())
                {
                    int id = reader.GetInt32(0);
                    string name = reader.GetString(1);
                    int age = reader.GetInt32(2);
                    string rank = reader.GetString(3);
                    shinobis.Add(new Shinobi { Id = id, Name = name, Age = age, Rank = rank });
                }
                conn.Close();
                return shinobis;
            }
            catch (Exception e)
            {
            }
            return shinobis;
        }

        // GET: api/Shinobi/5
        public Shinobi Get(int id)
        {
            MySqlConnection conn = new MySqlConnection(connectionString);
            try
            {
                conn.Open();
                MySqlDataReader reader;
                MySqlCommand cmd = new MySqlCommand("select * from shinobis where id = @0", conn);
                cmd.Parameters.AddWithValue("0", id);
                reader = cmd.ExecuteReader();
                reader.Read();
                int idx = reader.GetInt32(0);
                string name = reader.GetString(1);
                int age = reader.GetInt32(2);
                string rank = reader.GetString(3);
                conn.Close();
                return new Shinobi { Id = id, Name = name, Age = age, Rank = rank };
            }
            catch (Exception e)
            {
                conn.Close();
            }
            conn.Close();
            return null;
        }

        // POST: api/Shinobi
        public void Post(Shinobi s)
        {
            MySqlConnection conn = new MySqlConnection(connectionString);
            try
            {
                conn.Open();
                MySqlCommand cmd = conn.CreateCommand();
                string sql = "insert into shinobis values (@Id, @Name, @Age, @Rank)";
                cmd.CommandText = sql;
                cmd.Parameters.AddWithValue("@Id", s.Id);
                cmd.Parameters.AddWithValue("@Name", s.Name);
                cmd.Parameters.AddWithValue("@Age", s.Age);
                cmd.Parameters.AddWithValue("@Rank", s.Rank);
                cmd.ExecuteNonQuery();
                conn.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                conn.Close();
            }
        }

        // PUT: api/Shinobi/5
        public void Put(Shinobi s)
        {
            MySqlConnection conn = new MySqlConnection(connectionString);
            try
            {
                conn.Open();
                MySqlCommand cmd = conn.CreateCommand();
                string sql = "update shinobis " +
                    "set name = @Name, " +
                    "age = @Age, " +
                    "shinobis.rank = @Rank " +
                    "where id = @Id";
                cmd.CommandText = sql;             
                cmd.Parameters.AddWithValue("@Name", s.Name);
                cmd.Parameters.AddWithValue("@Age", s.Age);
                cmd.Parameters.AddWithValue("@Rank", s.Rank);
                cmd.Parameters.AddWithValue("@Id", s.Id);
                cmd.ExecuteNonQuery();
                conn.Close();
            }
            catch (Exception e)
            {
                conn.Close();
            }
        }

        // DELETE: api/Shinobi/5
        public void Delete(int id)
        {
            MySqlConnection conn = new MySqlConnection(connectionString);
            try
            {
                conn.Open();
                MySqlCommand cmd = conn.CreateCommand();
                string sql = "delete from shinobis where id = @id";
                cmd.CommandText = sql;
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
                conn.Close();
            }
            catch (Exception e)
            {
                conn.Close();
            }
        }
    }
}
