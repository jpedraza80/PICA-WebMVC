using Pica.Taller.Core.Entities;
using System.Threading.Tasks;

namespace Pica.Taller.Core.Interfaces
{
    public interface IContactService
    {
        Task<ContactInfo> Get(string email);

        Task<ContactInfo> Update(ContactInfo contact);
    }
}