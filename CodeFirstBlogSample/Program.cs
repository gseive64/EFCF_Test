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
                //Console.Write("Enter a name for a new blog:");
                //var name = Console.ReadLine();

//                var post = new Post { Title = "Our standard title..." };
//                var post2 = new Post { Title = "Our fancy title ;-)" };
//                var blog = new Blog { Name = name + " 1", Posts = new List<Post> {post, post2} };
////                var blog2 = new Blog { Name = name + " 2", Posts = new List<Post> { post } };
//                db.Blogs.AddRange(new List<Blog> { blog });
//                db.SaveChanges();

                //var query = from b in db.Blogs
                //            orderby b.Name
                //            select b;
                var blogs = db.Blogs;//.Include(b => b.Posts);
                
                foreach (var b in blogs)
                {
                    //var postsText = "";
                    //if (b.Posts != null && b.Posts.Count > 0)
                    //{
                    //    var postsTitles = b.Posts.Select(p => p.Title);
                    //    postsText = postsTitles.Aggregate((a, t) => t + " " + a);
                    //}
                    foreach (var p in b.Posts)
                    {                        
                        Console.WriteLine(b.Name + " " + p.Title);
                    }
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
