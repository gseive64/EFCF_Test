using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirstBlogSample
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var db = new BlogContext())
            {
                Console.Write("Enter a name for a new blog: ");
                var name = Console.ReadLine();

                var post = new Post { Title = "Our standard title...", Content = "What can I say?" };
                var post2 = new Post { Title = "Our fancy title ;-)" , Content = "This is what they do in France..." };
                var blog = new Blog { Name = name + " 1", Posts = new List<Post> { post, post2 } };
                // Did a test with two different Blogs sharing a post: one of the blogs didn't get his copy of the post; apparently there is no sharing going on!
                //                var blog2 = new Blog { Name = name + " 2", Posts = new List<Post> { post } };
                db.Blogs.AddRange(new List<Blog> { blog });
                db.SaveChanges();

                //var query = from b in db.Blogs
                //            orderby b.Name
                //            select b;
                var blogs = db.Blogs;//.Include(b => b.Posts);
                
                foreach (var b in blogs)
                {
                    var postsText = "";
                    if (b.Posts.Count > 0)
                    {
                        var postsTitles = b.Posts.Select(p => p.Title);
                        postsText = postsTitles.Aggregate((a, t) => t + " " + a);
                        Console.WriteLine(b.Name + " " + postsText);
                    }
                    //foreach (var p in b.Posts)
                    //{                        
                    //    Console.WriteLine(b.Name + " " + p.Title);
                    //}
                }
            }
        }
    }

    public class Blog
    {
        public int BlogId { get; set; }
        public string Name { get; set; }

        public virtual List<Post> Posts { get; set; }
    }

    class BlogContext : DbContext
    {
        public BlogContext()
        {
        }
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Post> Posts { get; set; }
    }
}
