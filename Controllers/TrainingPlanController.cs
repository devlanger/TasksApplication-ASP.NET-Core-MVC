using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace TasksApplication.Controllers
{
    public class TrainingPlanController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

    }
}
