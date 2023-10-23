﻿using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using RazorPages.Models;
using RazorPagesZenSpaCh7.Models;

namespace RazorPages.Controllers
{
    public class HomeController : Controller
    {
        private readonly SpaContext _context;

        public HomeController(SpaContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult InquiryForm()
        {
            ViewBag.Posted = false;
            ViewData["ServicesID"] = new SelectList(_context.Services, "Classification", "Classification");
            return View();
        }
        [HttpPost]
        public IActionResult InquiryForm(Contact model)
        {
            ViewBag.Posted = true;
            return View(model);
        }
        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult Employees()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
