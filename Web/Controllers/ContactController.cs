using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Pica.Taller.Mvc.Models;
using Pica.Taller.Web.Interfaces;
using System.Threading.Tasks;

namespace Pica.Taller.Mvc.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        public readonly IContactViewModelService ContactService;

        public ContactController(IContactViewModelService contactService)
        {
            ContactService = contactService;
        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ContactViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            model = await ContactService.Update(model);

            return Accepted(model);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            ContactViewModel model = await ContactService.Get(User.Identity.Name);
            return Ok(model);
        }
    }
}