using Auctions.API.Contracts;
using Auctions.API.Dtos.Requests;
using Auctions.API.Entities;
using Auctions.API.Repositories;
using Auctions.API.Repositories.DataAccess;
using Auctions.API.Services;

namespace Auctions.API.UseCases.Offers.CreateOffer
{
    public class CreateOfferUseCase
    {
        private readonly ILoggedUser _loggedUser;
        private readonly IOfferRepository _offerRepository;
        public CreateOfferUseCase(ILoggedUser loggedUser, IOfferRepository offerRepository)
        {
            _loggedUser = loggedUser;
            _offerRepository = offerRepository;
        }

        public int Execute(int itemId, RequestCreateOfferDto request)
        {
            var user = _loggedUser.User();

            var offer = new Offer
            {
                CreatedOn = DateTime.Now,
                ItemId = itemId,
                Price = request.Price,
                UserId = user.Id
            };

            _offerRepository.Add(offer);

            return offer.Id;
        }
    }
}
