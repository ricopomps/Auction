using Auctions.API.Contracts;
using Auctions.API.Entities;

namespace Auctions.API.UseCases.Auctions.GetCurrent
{
    public class GetCurrentAuctionUseCase
    {
        private readonly IAuctionRepository _repository;

        public GetCurrentAuctionUseCase(IAuctionRepository repository) => _repository = repository;
        public Auction? Execute()
        {
            return _repository.GetCurrent();
        }
    }
}
