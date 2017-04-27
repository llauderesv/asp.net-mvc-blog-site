using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace BlogMoto.Models
{
    public class BlogDBContext : DbContext
    {
        public DbSet<Blog> Blogs { get; set; }
    }
}