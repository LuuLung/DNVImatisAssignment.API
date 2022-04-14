using DNVImatisAssignment.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DNVImatisAssignment.Repositories
{
    public interface IPackagesRepository
    {
        Task<List<Package>> GetPackagesPromotionByCompany(string companyId);
    }

    public class PackagesRepository : IPackagesRepository
    {
        private readonly ApplicationContext _context;
        public PackagesRepository(ApplicationContext context)
        {
            _context = context;
        }
        public async Task<List<Package>> GetPackagesPromotionByCompany(string companyId)
        {
            return await _context.Packages
                            .Include(x => x.Promotions.Where(s=>s.IdCompany == companyId))
                            .AsNoTracking().ToListAsync();
            
        }
    }
}