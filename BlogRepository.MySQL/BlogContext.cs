using BlogModel;
using MySql.Data.Entity;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Data.Entity.Infrastructure.Annotations;

namespace BlogRepository.MySQL
{
    [DbConfigurationType(typeof(MySqlEFConfiguration))]
    public class BlogContext : DbContext
    {
        public BlogContext() : base("name=BlogContext")

        {
            

        }
        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{
        //    Database.SetInitializer(new MigrateDatabaseToLatestVersion<BlogContext, Migrations.Configuration>());
        //}

        public DbSet<Post> Posts { get; set; }
    }
}
