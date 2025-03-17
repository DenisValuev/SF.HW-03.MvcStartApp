using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MvcStartApp.Models.Db;
using System;
using System.Threading.Tasks;

namespace MvcStartApp.Models
{
    public class BlogRepository : IBlogRepository
    {
        //Ссылка на контекст
        private readonly BlogContext _context;

        //Метод-конструктор для инициализации
        public BlogRepository(BlogContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task Register(User user)
        {
            user.JoinDate = DateTime.Now;
            user.Id = Guid.NewGuid();

            // Добавление пользователя
            var entry = _context.Entry(user);
            if (entry.State == EntityState.Detached)
                await _context.Users.AddAsync(user);

            // Сохранение изменений
            await _context.SaveChangesAsync();
            return;
        }

        public async Task<User[]> GetUsers()
        {
            //Получим всех активных пользователей
            return await _context.Users.ToArrayAsync();
        }
    }
}
