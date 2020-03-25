using System.Drawing;
using DTBlog.Data.Model;
using Microsoft.EntityFrameworkCore;

namespace DTBlog.Data.Context
{
    public class MasterContext : DbContext
    {
        public MasterContext()
        {
        }

        public MasterContext(DbContextOptions<MasterContext> options)
        {

        }

        public DbSet<UserModel> UserModels { get; set; }
        public DbSet<AuthorModel> AuthorModels { get; set; }
        public DbSet<MusicModel> MusicModels { get; set; }
        public DbSet<NewsModel> NewsModels { get; set; }
        public DbSet<PostModel> PostModels { get; set; }
        public DbSet<QuotationModel> QuotationModels { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserModel>()
                .Property(c => c.IsSuperAdmin)
                .HasConversion<short>();

            modelBuilder.Entity<AuthorModel>()
                .HasMany(m => m.PostModels)
                .WithOne(c => c.AuthorModel)
                .HasForeignKey(k => k.AuthorId);

            //UserId referansları
            modelBuilder.Entity<UserModel>()
                .HasMany(m => m.AuthorModels)
                .WithOne(c => c.UserModel)
                .HasForeignKey(k => k.UserId);

            modelBuilder.Entity<UserModel>()
                .HasMany(m => m.MusicModels)
                .WithOne(c => c.UserModel)
                .HasForeignKey(k => k.UserId);

            modelBuilder.Entity<UserModel>()
                .HasMany(m => m.NewsModels)
                .WithOne(c => c.UserModel)
                .HasForeignKey(k => k.UserId);

            modelBuilder.Entity<UserModel>()
                .HasMany(m => m.PostModels)
                .WithOne(c => c.UserModel)
                .HasForeignKey(k => k.UserId);

            modelBuilder.Entity<UserModel>()
                .HasMany(m => m.QuotationModels)
                .WithOne(c => c.UserModel)
                .HasForeignKey(k => k.UserId);

            //ChangeUser referansları
            modelBuilder.Entity<AuthorModel>()
                .HasOne(m => m.ChangedUser)
                .WithMany(c => c.ChangeUserAuthor)
                .HasForeignKey(k => k.ChangedUserId);

            modelBuilder.Entity<MusicModel>()
                .HasOne(m => m.ChangedUser)
                .WithMany(c => c.ChangeUserMusic)
                .HasForeignKey(k => k.ChangedUserId);

            modelBuilder.Entity<NewsModel>()
                .HasOne(m => m.ChangedUser)
                .WithMany(c => c.ChangeUserNews)
                .HasForeignKey(k => k.ChangedUserId);

            modelBuilder.Entity<PostModel>()
                .HasOne(m => m.ChangedUser)
                .WithMany(c => c.ChangeUserPost)
                .HasForeignKey(k => k.ChangedUserId);

            modelBuilder.Entity<QuotationModel>()
                .HasOne(m => m.ChangedUser)
                .WithMany(c => c.ChangeUserQuot)
                .HasForeignKey(k => k.ChangedUserId);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseMySQL("server=localhost;port=3306;database=dtblog;user=root;password=root;");
            }
            base.OnConfiguring(optionsBuilder);
        }
    }
}
