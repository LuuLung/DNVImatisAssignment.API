using DNVImatisAssignment.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace DNVImatisAssignment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompaniesController : ControllerBase
    {
        private readonly ICompaniesService _companiesService;

        public CompaniesController(ICompaniesService companiesService)
        {
            _companiesService = companiesService;
        }

        [HttpGet]
        public async Task<IActionResult> GetCompanies()
        {
            var companies = await _companiesService.GetCompanies();
            return Ok(companies);
        }
    }
}