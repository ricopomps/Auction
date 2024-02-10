using Auction.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace Auction.API.Repositories
{
    public class AuctionDbContext :DbContext
    {
        public DbSet<AuctionEntity> Auctions { get; set; }
        public DbSet<Offer> Offers{ get; set; }
        public DbSet<User> Users{ get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=C:\\Users\\ricar\\Downloads\\leilaoDbNLW.db");
        }
    }
}
