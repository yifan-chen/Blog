using BlogModel;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace BlogRepository
{
    public class BlogRepository
    {
       // private static List<Post> posts = new List<Post>()
       // {
       //     new Post()
       //     {
       //     ID=1,
       //     Author="Bug收割机",
       //     Content="文章1的内容",
       //     CreateDate = DateTime.Now,
       //     ModifyDate =DateTime.Now,
       //     Title="文章1"
       //     },
       //     new Post()
       //     {
       //     ID=2,
       //     Author="Bug收割机",
       //     Content="文章2的内容",
       //     CreateDate = DateTime.Now,
       //     ModifyDate =DateTime.Now,
       //     Title="文章2"
       //     },
       //     new Post()
       //     {
       //     ID=3,
       //     Author="Bug收割机",
       //     Content="文章3的内容",
       //     CreateDate = DateTime.Now,
       //     ModifyDate =DateTime.Now,
       //     Title="文章3"
       //     },
       //     new Post()
       //     {
       //     ID=4,
       //     Author="Bug收割机",
       //     Content="文章4的内容",
       //     CreateDate = DateTime.Now,
       //     ModifyDate =DateTime.Now,
       //     Title="文章4"
       //     },
       //     new Post()
       //     {
       //     ID=5,
       //     Author="Bug收割机",
       //     Content="文章5的内容",
       //     CreateDate = DateTime.Now,
       //     ModifyDate =DateTime.Now,
       //     Title="文章5"
       //     }
       //};

        //public List<Post> GetAll()
        //{
        //    return posts;
        //}

        //public Post GetById(int id)
        //{
        //    return posts.Where(p => p.ID == id).FirstOrDefault();
        //}

        private string connectionString = "Data Source=.;Initial Catalog=MyBlog;Integrated Security=true";

        public List<Post> GetAll()
        {
            string queryString = "SELECT [ID], [Title],[Content],[CreateDate],[ModifyDate],[Author] FROM [MyBlog].[dbo].[Posts]";

            var result = new List<Post>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
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
            string queryString = "SELECT [ID], [Title],[Content],[CreateDate],[ModifyDate],[Author] FROM [MyBlog].[dbo].[Posts]"
                + "WHERE [ID] = @id";

            var result = new Post();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Parameters.AddWithValue("@id", id);
                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
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
                    throw ex;
                }
            }
            return result;
        }

        public void Insert(Post post)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string insertSql = @"INSERT INTO [dbo].[Posts]([ID],[Title],[Content],[CreateDate],[ModifyDate],[Author])
                              VALUES (@ID,@Title,@Content,@CreateDate,@ModifyDate,@Author)";
                using (SqlCommand cmd = new SqlCommand(insertSql, con))
                {
                    con.Open();
                    cmd.Parameters.AddWithValue("@ID", post.ID);
                    cmd.Parameters.AddWithValue("@Title", post.Title);
                    cmd.Parameters.AddWithValue("@Content", post.Content);
                    cmd.Parameters.AddWithValue("@CreateDate", DateTime.Now);
                    cmd.Parameters.AddWithValue("@ModifyDate", DateTime.Now);
                    cmd.Parameters.AddWithValue("@Author", post.Author);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Delete(int id)
        {
            //var oldpost = this.GetById(id);
            //if (oldpost != null)
            //{
            //    posts.Remove(oldpost);
            //}
        }

        public void Update(Post post)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string insertSql = @"UPDATE [dbo].[Posts]
                                    SET 
                                        [Title] = @Title,
                                        [Content] = @Content,
                                        [ModifyDate] = @ModifyDate
                                    WHERE [ID] = @ID";
                using (SqlCommand cmd = new SqlCommand(insertSql, con))
                {
                    con.Open();
                    cmd.Parameters.AddWithValue("@ID", post.ID);
                    cmd.Parameters.AddWithValue("@Title", post.Title);
                    cmd.Parameters.AddWithValue("@Content", post.Content);
                    cmd.Parameters.AddWithValue("@ModifyDate", DateTime.Now);
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
