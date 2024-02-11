﻿using System.Text;
using Auctions.API.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Auctions.API.Filters
{
    public class AuthenticationUserAttribute : AuthorizeAttribute, IAuthorizationFilter
    {
        private readonly IUserRepository _userRepository;
        public AuthenticationUserAttribute(IUserRepository userRepository) => _userRepository = userRepository;
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            try
            {
                var token = TokenOnRequest(context.HttpContext);

                var email = FromBase64String(token);

                var exists = _userRepository.ExistUserWithEmail(email);

                if (!exists)
                {
                    context.Result = new UnauthorizedObjectResult("E-mail not valid");
                }
            }
            catch (Exception ex)
            {
                context.Result = new UnauthorizedObjectResult(ex.Message);
            }
        }

        private string TokenOnRequest(HttpContext context)
        {
            var authentication = context.Request.Headers.Authorization.ToString();

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
