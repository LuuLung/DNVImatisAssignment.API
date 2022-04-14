using DNVImatisAssignment.API.Infrastructures.RequestsModel;
using DNVImatisAssignment.Entities;
using DNVImatisAssignment.Infrastructures;
using DNVImatisAssignment.Repositories;
using System.Linq;
using System.Threading.Tasks;

namespace DNVImatisAssignment.API.Services
{
    public interface IPricesService
    {
        Task<decimal> CalculatePriceWithPromotion(PriceCaculationRequest priceCaculationRequest);
    }

    public class PricesService : IPricesService
    {
        private readonly IPackagesRepository _packagesRepository;

        public PricesService(IPackagesRepository packagesRepository)
        {
            _packagesRepository = packagesRepository;
        }

        public async Task<decimal> CalculatePriceWithPromotion(PriceCaculationRequest priceCaculationRequest)
        {
            var packages = await _packagesRepository.GetPackagesPromotionByCompany(priceCaculationRequest.CompanyId);
            decimal totalPrice = 0;
            if (packages == null || !packages.Any())
            {
                return totalPrice;
            }
            foreach (var packageReq in priceCaculationRequest.Packages)
            {
                var packageDB = packages.FirstOrDefault(x => x.Id == packageReq.PackageId);
                if (packageDB == null)
                {
                    continue;
                }
                totalPrice = totalPrice + packageReq.NumberOfPackage * packageDB.Price;
                ApplyPromotion(ref totalPrice, packageDB, packageReq.NumberOfPackage);
            }
            return totalPrice;
        }

        private void ApplyPromotion(ref decimal originalPrice, Package package, int orderNumber)
        {
            if (package == null || package.Promotions == null || !package.Promotions.Any())
            {
                return;
            }
            foreach (var promotion in package.Promotions)
            {
                decimal promotionPrice = 0;
                if (promotion.Type == (int)PromotionType.NumberPackage)
                {
                    promotionPrice = ((promotion.PackageActualNumber - promotion.PackageCaculateNumber)
                                            * (int)(orderNumber / promotion.PackageActualNumber)
                                      ) * package.Price;
                }
                else if (promotion.Type == (int)PromotionType.DropPrice)
                {
                    promotionPrice = (package.Price - promotion.PriceDropNumber) * orderNumber;
                }
                originalPrice = originalPrice - promotionPrice;
            }
        }
    }
}