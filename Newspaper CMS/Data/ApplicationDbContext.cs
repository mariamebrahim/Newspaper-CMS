using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Newspaper_CMS.Models;

namespace Newspaper_CMS.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Article> Articles { get; set; }
        public virtual DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Article>(entity =>
            {
                entity.HasKey(e => e.Article_ID);

                entity.Property(e => e.Article_PublishDate).HasColumnType("date");

                entity.Property(e => e.Article_Title)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Category_Name)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Writer_Name)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });


            modelBuilder.Entity<Category>(entity =>
            {
                entity.HasKey(e => e.Category_Name)
                    .HasName("PK_Category_1");

                entity.ToTable("Category");

                entity.Property(e => e.Category_Name)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            base.OnModelCreating(modelBuilder);
        }
    }
}