using DNVImatisAssignment.Entities;
using DNVImatisAssignment.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DNVImatisAssignment.Services
{
    public interface IPackageService
    {
        Task<List<Package>> GetPackagesWithPromotionByCompany(string companyId);
    }
    public class PackagesService: IPackageService
    {
        readonly IPackagesRepository _packagesRepository;
        public PackagesService(IPackagesRepository packagesRepository)
        {
            _packagesRepository = packagesRepository;
        }

        public async Task<List<Package>> GetPackagesWithPromotionByCompany(string companyId)
        {
            return await _packagesRepository.GetPackagesPromotionByCompany(companyId);
        }
    }
}