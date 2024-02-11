using Auctions.API.Entities;

namespace Auctions.API.Contracts
{
    public interface IUserRepository
    {
        bool ExistUserWithEmail(string email);
        User GetUserByEmail(string email);
    }
}
