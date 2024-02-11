using Auctions.API.Contracts;
using Auctions.API.Entities;
using Auctions.API.Services;

namespace Auctions.API.Repositories.DataAccess
{
    public class OfferRepository : IOfferRepository
    {
        private readonly AuctionDbContext _dbContext;
        public OfferRepository(AuctionDbContext auctionDbContext) => _dbContext = auctionDbContext;

        public void Add(Offer offer)
        {
            _dbContext.Offers.Add(offer);

            _dbContext.SaveChanges();
        }
    }
}
