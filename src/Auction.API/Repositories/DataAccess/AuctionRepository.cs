using Auctions.API.Contracts;
using Auctions.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace Auctions.API.Repositories.DataAccess
{
    public class AuctionRepository : IAuctionRepository
    {
        private readonly AuctionDbContext _dbContext;
        public AuctionRepository(AuctionDbContext auctionDbContext) => _dbContext = auctionDbContext;

        public Auction? GetCurrent()
        {
            var today = DateTime.Now;

            return _dbContext.Auctions.Include(auction => auction.Items).FirstOrDefault(auction => today >= auction.Starts && today <= auction.Ends);
        }
    }
}
