using System.Runtime.CompilerServices;
using System.Security.Claims;
using System.Web.Providers.Entities;

namespace CatstgramApp.Extensions
{
    public static class IdentityExtension
    {
        public static string GetId(this ClaimsPrincipal user)
         => user.Claims
            .FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)
            ?.Value;
        
    }           
}
