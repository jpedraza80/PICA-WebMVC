using Pica.Taller.Core.Entities;
using System.Threading.Tasks;

namespace Pica.Taller.Core.Interfaces
{
    public interface IContactRepository
    {
        Task<ContactInfo> Get(string email);

        Task Add(ContactInfo contact);

        Task Update(ContactInfo current);
    }
}