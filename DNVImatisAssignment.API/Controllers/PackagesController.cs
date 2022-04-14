using DNVImatisAssignment.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace DNVImatisAssignment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PackagesController : ControllerBase
    {
        private readonly IPackageService _packagesService;

        public PackagesController(IPackageService packagesService)
        {
            _packagesService = packagesService;
        }

        [HttpGet()]
        public async Task<IActionResult> GetPackagesWithPromotionById([FromQuery(Name = "CompanyId")] string IdCompany)
        {
            var packages = await _packagesService.GetPackagesWithPromotionByCompany(IdCompany);
            return Ok(packages);
        }
    }
}