using System.Collections.Generic;
using IdentityModel;
using IdentityServer4;
using IdentityServer4.Models;

namespace Records.Identity
{
    public static class Configuration
    {
        public static IEnumerable<ApiScope> ApiScopes =>
            new List<ApiScope>
            {
                new ApiScope("RecordsWebAPI", "Web API")
            };

        public static IEnumerable<IdentityResource> IdentityResources =>
           new List<IdentityResource>
           {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile()
           };

        public static IEnumerable<ApiResource> ApiResources =>
            new List<ApiResource>
            {
                new ApiResource("RecordsWebAPI", "Web API", new []
                    {JwtClaimTypes.Name})
                {
                    Scopes = {"RecordsWebAPI"}
                }
            };

        public static IEnumerable<Client> Clients =>
            new List<Client>
            {
                new Client
                {
                    ClientId = "records-web-app",
                    ClientName = "Records Web",
                    AllowedGrantTypes = GrantTypes.Code,
                    RequireClientSecret = false,
                    RequirePkce = true,
                    RedirectUris =
                    {
                        "http:// .../signin-oidc"
                    },
                    AllowedCorsOrigins =
                    {
                        "http:// ..."
                    },
                    PostLogoutRedirectUris =
                    {
                        "http:// .../signout-oidc"
                    },
                    AllowedScopes =
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        "RecordsWebAPI"
                    },
                    AllowAccessTokensViaBrowser = true
                }
            };
    }
}