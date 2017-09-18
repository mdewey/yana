using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using StackOverflow.Models;
using StackOverflow;

namespace StackOverflow.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }

        public DbSet<StackOverflow.UserModel> UserModel { get; set; }

        public DbSet<StackOverflow.Models.TagsModel> TagsModel { get; set; }

        public DbSet<StackOverflow.Models.QuestionsModel> QuestionsModel { get; set; }

        public DbSet<StackOverflow.Models.QTiesModel> QTiesModel { get; set; }

        public DbSet<StackOverflow.Models.CommentsModel> CommentsModel { get; set; }
    }
}
