﻿using Microsoft.AspNetCore.Mvc;
using MvcStartApp.Models;
using MvcStartApp.Models.Db;
using System.Threading.Tasks;

namespace MvcStartApp.Controllers
{
    public class UsersController : Controller
    {
        private readonly IBlogRepository _repo;

        public UsersController(IBlogRepository repo)
        {
            _repo = repo;
        }

        public async Task<IActionResult> Index()
        {
            var authors = await _repo.GetUsers();
            return View(authors);
        }
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(User newUser)
        {
            await _repo.Register(newUser);
            return View(newUser);
        }
    }
}
