using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Pica.Taller.Mvc.Models;
using Pica.Taller.Web.Interfaces;
using System;
using System.Threading.Tasks;

namespace Pica.Taller.Mvc.Controllers
{
    [Authorize]
    public class MembersController : Controller
    {
        public readonly IContactViewModelService ContactService;

        public MembersController(IContactViewModelService contactService)
        {
            ContactService = contactService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [Authorize(Roles = "Member")]
        public async Task<IActionResult> Contact()
        {
            ContactViewModel model = await ContactService.Get(User.Identity.Name);
            return View(model);
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
        public async Task<IActionResult> Contact(ContactViewModel model)
        {
            IActionResult result = View(model);
            if (ModelState.IsValid)
            {
                await ContactService.Update(model);
                result = RedirectToAction("Acknowledgment");
            }
            return result;
        }
    }
}