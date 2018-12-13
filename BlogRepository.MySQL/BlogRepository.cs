using BlogModel;
using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using System.Linq;
using System.Data.Entity;

namespace BlogRepository.MySQL
{
    public class BlogRepository
    {

        public List<Post> GetAll()
        {
            using (var dbcontext = new BlogContext())
            {
                return dbcontext.Posts.ToList();
            }
        }

        public List<Post> GetTop5()
        {
            using (var dbcontext = new BlogContext())
            {
                return dbcontext.Posts.OrderByDescending(p => p.ClickCount).Take(5).ToList();
            }
        }

        public Post GetById(int id)
        {
            using (var dbcontext = new BlogContext())
            {
                return dbcontext.Posts.Find(id);
            }
        }

        public void Update(Post post)
        {
            using (var dbcontext = new BlogContext())
            {
                dbcontext.Entry(post).State = EntityState.Modified;
                dbcontext.SaveChanges();
            }
        }

        public void Insert(Post post)
        {
            using (var dbcontext = new BlogContext())
            {
                dbcontext.Posts.Add(post);
                dbcontext.SaveChanges();
            }
        }

        public void Delete(Post post)
        {
            using (var dbcontext = new BlogContext())
            {
                dbcontext.Posts.Remove(post);
                dbcontext.SaveChanges();
            }
        }

        /*  private string connectionString = "server=localhost;user=my;database=my_blog;port=3306;password=a12345678";

          public List<Post> GetAll()
          {
              string queryString = "SELECT ID, Title,Content,CreateDate,ModifyDate,Author FROM posts";

              var result = new List<Post>();
              using (MySqlConnection connection = new MySqlConnection(connectionString))
              {
                  MySqlCommand command = new MySqlCommand(queryString, connection);
                  try
                  {
                      connection.Open();
                      MySqlDataReader reader = command.ExecuteReader();
                      while (reader.Read())
                      {
                          result.Add(new Post()
                          {
                              Author = reader["Author"].ToString(),
                              Content = reader["Content"].ToString(),
                              CreateDate = DateTime.Parse(reader["CreateDate"].ToString()),
                              ModifyDate = DateTime.Parse(reader["ModifyDate"].ToString()),
                              ID = int.Parse(reader["ID"].ToString()),
                              Title = reader["Title"].ToString(),
                          });
                      }
                      reader.Close();
                  }
                  catch (Exception ex)
                  {
                  }
              }
              return result;
          }

          public Post GetById(int id)
          {
              string queryString = "SELECT ID, Title,Content,CreateDate,ModifyDate,Author FROM posts"
                  + " WHERE ID = @id";

              var result = new Post();
              using (MySqlConnection connection = new MySqlConnection(connectionString))
              {
                  MySqlCommand command = new MySqlCommand(queryString, connection);
                  command.Parameters.AddWithValue("@id", id);
                  try
                  {
                      connection.Open();
                      MySqlDataReader reader = command.ExecuteReader();
                      while (reader.Read())
                      {
                          result = new Post()
                          {
                              Author = reader["Author"].ToString(),
                              Content = reader["Content"].ToString(),
                              CreateDate = DateTime.Parse(reader["CreateDate"].ToString()),
                              ModifyDate = DateTime.Parse(reader["ModifyDate"].ToString()),
                              ID = int.Parse(reader["ID"].ToString()),
                              Title = reader["Title"].ToString(),
                          };
                      }
                      reader.Close();
                  }
                  catch (Exception ex)
                  {
                  }
              }
              return result;
          }*/
    }
}
