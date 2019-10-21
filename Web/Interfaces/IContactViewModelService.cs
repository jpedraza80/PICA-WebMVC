using Pica.Taller.Mvc.Models;
using System.Threading.Tasks;

namespace Pica.Taller.Web.Interfaces
{
    public interface IContactViewModelService
    {
        Task<ContactViewModel> Update(ContactViewModel model);

        Task<ContactViewModel> Get(string email);
    }
}