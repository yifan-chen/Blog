using BlogModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogBusinessLogic
{
    public class BlogManager
    {
        private BlogRepository.MySQL.BlogRepository repository = new BlogRepository.MySQL.BlogRepository();

        public List<Post> GetAllPosts()
        {
            return repository.GetAll();
        }

        public List<Post> GetTop5()
        {
            return repository.GetTop5();
        }

        public Post GetPostById(int id)
        {
            return repository.GetById(id);
        }

        public void UpdatePost(Post post)
        {
            repository.Update(post);
        }

        public void Insert(Post post)
        {
            repository.Insert(post);
        }
    }
}
