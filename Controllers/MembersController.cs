using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Pica.Taller.Mvc.Models;

namespace Pica.Taller.Mvc.Controllers
{
    [Authorize]
    public class MembersController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [Authorize(Roles = "Member")]
        public IActionResult Contact()
        {
            return View();
        }

        public IActionResult Acknowledgment()
        {
            return View();
        }

        public IActionResult RaiseException()
        {
            throw new NotImplementedException("Este metodo genera una excepcion al ejecutarse");
        }

        [HttpPost]
        [Authorize(Roles = "Member")]
        public IActionResult Contact(ContactViewModel model)
        {
            IActionResult result = View(model);
            if (ModelState.IsValid)
            {
                result = RedirectToAction("Acknowledgment");
            }
            return result;
        }
    }
}