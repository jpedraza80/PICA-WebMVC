using Pica.Taller.Core.Entities;
using Pica.Taller.Core.Interfaces;
using Pica.Taller.Mvc.Models;
using Pica.Taller.Web.Interfaces;
using System.Threading.Tasks;

namespace Pica.Taller.Web.Services
{
    public class ContactViewModelService : IContactViewModelService
    {
        public readonly IContactService ContactService;

        public ContactViewModelService(IContactService contactService)
        {
            ContactService = contactService;
        }

        public async Task<ContactViewModel> Get(string email)
        {
            ContactViewModel model = new ContactViewModel();
            ContactInfo contact = await ContactService.Get(email);

            if (contact != null)
            {
                model.Address = contact.Address;
                model.Email = contact.Email;
                model.Name = contact.FullName;
            }
            return model;
        }

        public async Task<ContactViewModel> Update(ContactViewModel model)
        {
            await ContactService.Update(new ContactInfo
            {
                Address = model.Address,
                Email = model.Email,
                FullName = model.Name
            });

            return model;
        }
    }
}