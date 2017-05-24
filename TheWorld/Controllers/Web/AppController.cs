using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TheWorld.Models;
using TheWorld.Services;
using TheWorld.ViewModels;

namespace TheWorld.Controllers.Web
{
    public class AppController : Controller
    {
        private IMailService _mailService;
        private WorldContext _context;

        public AppController (IMailService mailService, WorldContext context)
        {
            _mailService = mailService;
            _context = context;
        }

        public IActionResult Index ()
        {
            var data = _context.Trips.ToList ();
            return View(data);
        }

        public IActionResult Contact()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Contact(ContactViewModel model)
        {
            _mailService.SendMail("Josh@Baert.io",model.Email, "From The World", model.Message );

            return View ();
        }

        public IActionResult About()
        {
            return View();
        }
    }
}
