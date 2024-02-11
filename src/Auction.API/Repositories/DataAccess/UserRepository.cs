using Auctions.API.Contracts;
using Auctions.API.Entities;

namespace Auctions.API.Repositories.DataAccess
{
    public class UserRepository : IUserRepository
    {
        private readonly AuctionDbContext _dbContext;
        public UserRepository(AuctionDbContext auctionDbContext) => _dbContext = auctionDbContext;

        public bool ExistUserWithEmail(string email)
        {
            return _dbContext.Users.Any(user => user.Email.Equals(email));
        }

        public User GetUserByEmail(string email)
        {
            return _dbContext.Users.First(User => User.Email.Equals(email));
        }
    }
}
