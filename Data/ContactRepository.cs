using Microsoft.EntityFrameworkCore;
using Pica.Taller.Core.Entities;
using Pica.Taller.Core.Interfaces;
using System.Threading.Tasks;

namespace Pica.Taller.Data
{
    public class ContactRepository : IContactRepository
    {
        private readonly TallerContext DbContext;

        public ContactRepository(TallerContext dbContext)
        {
            DbContext = dbContext;
        }

        public Task Add(ContactInfo contact)
        {
            DbContext.Contacts.Add(contact);
            return DbContext.SaveChangesAsync();
        }

        public Task<ContactInfo> Get(string email)
        {
            return DbContext.Contacts.FirstOrDefaultAsync(x =>
                x.Email == email);
        }

        public Task Update(ContactInfo current)
        {
            return DbContext.SaveChangesAsync();
        }
    }
}