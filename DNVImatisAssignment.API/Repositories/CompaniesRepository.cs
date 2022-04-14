using DNVImatisAssignment.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DNVImatisAssignment.Repositories
{
    public interface ICompaniesRepository
    {
        Task<List<Company>> GetCompanies();
    }

    public class CompaniesRepository : ICompaniesRepository
    {
        private readonly ApplicationContext _context;

        public CompaniesRepository(ApplicationContext context)
        {
            _context = context;
        }

        public async Task<List<Company>> GetCompanies()
        {
            return await  _context.Companies.AsNoTracking().ToListAsync();
        }
    }
}