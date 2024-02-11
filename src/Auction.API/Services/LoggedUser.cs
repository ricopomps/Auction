using System.Text;
using Auctions.API.Contracts;
using Auctions.API.Entities;

namespace Auctions.API.Services
{
    public class LoggedUser : ILoggedUser
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IUserRepository _userRepository;
        public LoggedUser(IHttpContextAccessor httpContext, IUserRepository userRepository)
        {
            _httpContextAccessor = httpContext;
            _userRepository = userRepository;
        }

        public User User()
        {
            var token = TokenOnRequest();

            var email = FromBase64String(token);

            return _userRepository.GetUserByEmail(email);
        }

        private string TokenOnRequest()
        {
            var authentication = _httpContextAccessor.HttpContext!.Request.Headers.Authorization.ToString();

            if (string.IsNullOrEmpty(authentication))
            {
                throw new Exception("Token is missing.");
            }

            return authentication["Bearer ".Length..];
        }

        private string FromBase64String(string base64)
        {
            var data = Convert.FromBase64String(base64);
            return Encoding.UTF8.GetString(data);
        }
    }
}
