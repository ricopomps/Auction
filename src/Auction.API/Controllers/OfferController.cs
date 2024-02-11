using Auctions.API.Dtos.Requests;
using Auctions.API.Filters;
using Auctions.API.UseCases.Offers.CreateOffer;
using Microsoft.AspNetCore.Mvc;

namespace Auctions.API.Controllers
{
    [ServiceFilter(typeof(AuthenticationUserAttribute))]
    public class OfferController : AuctionBaseController
    {
        [HttpPost("{itemId}")]
        public IActionResult CreateOffer([FromRoute] int itemId, [FromBody] RequestCreateOfferDto request,
            [FromServices] CreateOfferUseCase useCase)
        {
            var id = useCase.Execute(itemId, request);

            return Created(string.Empty, id);
        }
    }
}
