using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BlazorSampleApp.Pages
{
    [AllowAnonymous]
    public class LoginModel : PageModel
    {
        [FromQuery(Name = "ReturnUrl")]
        public string ReturnAddress { get; set; } = "/";

        public async Task<IActionResult> OnPostAsync()
        {
            var claims = new List<Claim>
                         {
                             new Claim(ClaimTypes.Name, "name"), new Claim(ClaimTypes.NameIdentifier, "11")
                         };

            var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

            var authProperties = new AuthenticationProperties { IsPersistent = true };

            await HttpContext.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme,
                new ClaimsPrincipal(claimsIdentity),
                authProperties);

            return Redirect(ReturnAddress);
        }
    }
}