using Microsoft.EntityFrameworkCore;
using Pica.Taller.Core.Entities;

namespace Pica.Taller.Data
{
    public class TallerContext : DbContext
    {
        public TallerContext(DbContextOptions<TallerContext> options) :
            base(options)
        { }

        public DbSet<ContactInfo> Contacts { get; set; }
    }
}