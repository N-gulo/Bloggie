using BloggieWeb.Models.Domain;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace BloggieWeb.Data
{
    public class BloggieDbContext : DbContext
    {
        public BloggieDbContext(DbContextOptions<BloggieDbContext> options) : base(options)
        {
             
        }
        public DbSet<BlogPost> BlogPost { get; set; }
        public DbSet<Tag> Tags{ get; set; }
        public DbSet<BlogPostLike> BlogPostLike{ get; set; }
        public DbSet<BlogPostComment> BlogPostComment { get; set; }
    }
}
