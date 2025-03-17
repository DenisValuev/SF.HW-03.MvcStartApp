using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MvcStartApp.Models.Db;
using System;
using System.Threading.Tasks;

namespace MvcStartApp.Models
{
    public class RequestRepository : IRequestRepository
    {
        //Ссылка на контекст
        private readonly BlogContext _context;

        public RequestRepository(BlogContext context)
        {
            _context = context;
        }
        public async Task<Request[]> GetRequests()
        {
            return await _context.Requests.ToArrayAsync();
        }

        [HttpPost]
        public async Task Logging(Request request)
        {
            request.Date = DateTime.Now;
            request.Id = Guid.NewGuid();

            //Добавление запроса
            var entry = _context.Entry(request);
            if (entry.State == EntityState.Detached)
                await _context.Requests.AddAsync(request);

            await _context.SaveChangesAsync();
            return;
        }
    }
}
