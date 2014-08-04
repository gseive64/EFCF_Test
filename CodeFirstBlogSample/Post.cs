using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodeFirstBlogSample
{
    public class Post
    {
        public int PostId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }

        public string ToString()
        {
            return this.Title;
        }

        public int BlogId { get; set; }
        public virtual Blog Blog { get; set; }
    }
}
