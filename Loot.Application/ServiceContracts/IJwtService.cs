using System.Security.Claims;

namespace Loot.Application.ServiceContracts;

public interface IJwtService
{
    string GenerateAccessToken(IEnumerable<Claim> claims);
    string GenerateRefreshToken();
}