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

        /// <summary>
        /// Middleware-компонент должен иметь конструктор, принимающий RequestDelegate
        /// </summary>
        /// <param name="next"></param>
        public LoggingMidleware(RequestDelegate next)
        {
            _next = next;
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

            string url = $"New request to http://{context.Request.Host.Value + context.Request.Path}{Environment.NewLine}";
            DateTime dateTimeRequest = DateTime.Now;

            //string logRequest = $"{url} {dateTimeRequest}";
            context.Items["CurrentDateTime"] = dateTimeRequest;
            context.Items["URL"] = url;

            //Передача запроса далее по конвейеру
            await _next.Invoke(context);
        }
    }
}
