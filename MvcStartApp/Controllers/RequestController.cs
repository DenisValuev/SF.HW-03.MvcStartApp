using Microsoft.AspNetCore.Mvc;
using MvcStartApp.Models;
using MvcStartApp.Models.Db;
using System;
using System.Threading.Tasks;

namespace MvcStartApp.Controllers
{
    public class RequestController : Controller
    {
        private readonly IRequestRepository _logger;

        public RequestController(IRequestRepository logger)
        {
            _logger = logger;
        }
        [HttpPost]
        public async Task<IActionResult> Logs()
        {
            var valueUrl = HttpContext.Items["URL"] as string;
            if (HttpContext.Items.TryGetValue("CurrentDateTime", out var dateTimeObject))
            {
                DateTime valueDate = (DateTime)dateTimeObject;
                var newRequest = new Request()
                {
                    Id = Guid.NewGuid(),
                    Date = valueDate,
                    Url = valueUrl
                };
                await _logger.Logging(newRequest);
            }

            var Logs = await _logger.GetRequests();
            return View(Logs);
        }
    }
}