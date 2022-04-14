using DNVImatisAssignment.API.Infrastructures.RequestsModel;
using DNVImatisAssignment.API.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace DNVImatisAssignment.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PricesController : ControllerBase
    {
        private readonly IPricesService _priceService;

        public PricesController(IPricesService pricesService)
        {
            _priceService = pricesService;
        }

        [HttpPost()]
        public async Task<IActionResult> CaculateThePriceWithPromotion([FromBody] PriceCaculationRequest request)
        {
            var totalPrice = await _priceService.CalculatePriceWithPromotion(request);
            return Ok(totalPrice);
        }
    }
}