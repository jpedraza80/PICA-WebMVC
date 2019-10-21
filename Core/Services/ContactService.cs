using Pica.Taller.Core.Entities;
using Pica.Taller.Core.Interfaces;
using System.Threading.Tasks;

namespace Pica.Taller.Core.Services
{
    public class ContactService : IContactService
    {
        private readonly IContactRepository ContactRepository;

        public ContactService(IContactRepository contactRepository)
        {
            ContactRepository = contactRepository;
        }

        public Task<ContactInfo> Get(string email)
        {
            return ContactRepository.Get(email);
        }

        public async Task<ContactInfo> Update(ContactInfo contact)
        {
            ContactInfo current = await ContactRepository.Get(contact.Email);
            if (current != null)
            {
                current.Address = contact.Address;
                current.FullName = contact.FullName;

                await ContactRepository.Update(current);
            }
            else
            {
                current = new ContactInfo
                {
                    Email = contact.Email,
                    Address = contact.Address,
                    FullName = contact.FullName
                };
                await ContactRepository.Add(current);
            }
            return current;
        }
    }
}