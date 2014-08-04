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

                    // Display blog names and post titles
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
            this.Configuration.LazyLoadingEnabled = true;
        }
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Post> Posts { get; set; }
    }
}
