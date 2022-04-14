using DNVImatisAssignment.Entities;
using DNVImatisAssignment.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DNVImatisAssignment.Services
{
    public interface ICompaniesService
    {
        Task<List<Company>> GetCompanies();
    }

    public class CompaniesService : ICompaniesService
    {
        private readonly ICompaniesRepository _companiesRepository;

        public CompaniesService(ICompaniesRepository companiesRepository)
        {
            _companiesRepository = companiesRepository;
        }

        public async Task<List<Company>> GetCompanies()
        {
            return await _companiesRepository.GetCompanies();
        }
    }
}