using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MvcStartApp.Models;
using MvcStartApp.Models.Db;
using System;
using System.Threading.Tasks;

namespace MvcStartApp.Middlewares
{
    public class LoggingMidleware
    {
        private readonly RequestDelegate _next;
        private readonly IRequestRepository _repo;

        /// <summary>
        /// Middleware-компонент должен иметь конструктор, принимающий RequestDelegate
        /// </summary>
        /// <param name="next"></param>
        public LoggingMidleware(RequestDelegate next, IRequestRepository repo)
        {
            _next = next;
            _repo = repo;
        }

        /// <summary>
        /// Необходимо реализовать метод Invoke или InvokeSaync
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public async Task InvokeAsync(HttpContext context)
        {
            //Для логирования данных о запросе используем свойство объекта Httpcontext
            Console.WriteLine($"[{DateTime.Now}]: New request to http://{context.Request.Host.Value + context.Request.Path}");
            
            //Передача запроса далее по конвейеру
            await _next.Invoke(context);
        }
    }
}
