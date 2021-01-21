using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TasksApplication.Models;
using TasksApplication.Data;
using Microsoft.EntityFrameworkCore;

namespace TasksApplication.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _context;

        public HomeController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            if(!User.Identity.IsAuthenticated)
            {
                return Redirect("Identity/Account/Login");
            }

            var tasks = await _context.Tasks.ToListAsync();
            var daysOfMonth = GetDates(DateTime.Today.Year, DateTime.Today.Month);

            ViewBag.CurrentDay = DateTime.Now;

            var calendarDays = new List<CalendarDay>();
            foreach (var day in daysOfMonth)
            {
                var newCalendarDay = new CalendarDay()
                {
                    Date = day.Date,
                    Todoes = tasks.Where(t => t.Date.Date == day.Date).ToList()
                };

                calendarDays.Add(newCalendarDay);
            }

            return View(calendarDays);
        }

        public static List<DateTime> GetDates(int year, int month)
        {
            return Enumerable.Range(1, DateTime.DaysInMonth(year, month))  // Days: 1, 2 ... 31 etc.
                             .Select(day => new DateTime(year, month, day)) // Map each day to a date
                             .ToList(); // Load dates into a list
        }

        /*[HttpPost]
        [ValidateAntiForgeryToken]
        public Task<IActionResult> Create([Bind("Title, Description, Date")] )
        {
            await _context

            return View();
        }*/

        public IActionResult Privacy()
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
