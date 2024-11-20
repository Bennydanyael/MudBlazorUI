using Microsoft.AspNetCore.Components.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace MudBlazorData.Data
{
    public class CustomAuthenticationStateProvider : AuthenticationStateProvider
    {
        private ISessionStorageService _sessionStorageService;
        public CustomAuthenticationStateProvider(ISessionStorageService sessionStorageService)
        {
            _sessionStorageService = sessionStorageService;
        }
        public override Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            var _identity = new ClaimsIdentity();
            //{
            //    new Claim(ClaimTypes.Name, "admin.com")
            //}, "APIAuth_Type");

            var _user = new ClaimsPrincipal(_identity);
            return Task.FromResult(new AuthenticationState(_user));
        }

        public async Task NotifAuthenticated(string _email)
        {
            var _identity = new ClaimsIdentity(new[]
            {
                new Claim(ClaimTypes.Name, "admin.com")
            }, "APIAuth_Type");
            var _user = new ClaimsPrincipal(_identity);
            NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(_user)));
        }

        public void Logout()
        {
            _sessionStorageService.RemoveItemAsync("Email");
            var _identity = new ClaimsIdentity();
            var _user = new ClaimsPrincipal(_identity);
            NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(_user)));
        }
    }
}
