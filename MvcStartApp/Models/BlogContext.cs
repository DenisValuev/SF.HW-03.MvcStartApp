using Microsoft.EntityFrameworkCore;
using MvcStartApp.Models.Db;

namespace MvcStartApp.Models
{
    /// <summary>
    /// Класс контекста, предоставляющий доступ к сущностям базы данных
    /// </summary>
    public sealed class BlogContext : DbContext
    {
        //Ссылка на таблицу Users
        public DbSet<User> Users { get; set; }

        //Ссылка на таблицу UserPosr
        public DbSet<UserPost> UserPosts { get; set; }

        //Ссылка на таблицу Request
        public DbSet<Request> Requests { get; set; }

        //Логика взаимодействия с таблицами в БД
        public BlogContext(DbContextOptions<BlogContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
