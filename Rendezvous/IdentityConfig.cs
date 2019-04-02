using IdentityServer4.Models;
using System.Collections.Generic;

namespace Rendezvous
{
    public class IdentityConfig
    {
        public static IEnumerable<IdentityResource> GetIdentityResources()
        {
            return new IdentityResource[]
            {
                new IdentityResources.OpenId()
            };
        }

        public static IEnumerable<ApiResource> GetApiResources()
        {
            var api = new ApiResource("grc", "GRC -1 ")
            {
                Scopes = new Scope[] {
                new Scope("grc:clients.read_all"),
                new Scope("grc:clients.read"),
            }
            };
            return new List<ApiResource>
            {
                api                
            };
        }

        public static IEnumerable<Client> GetClients()
        {
            return new List<Client>
            {
                 new Client
                {
                    ClientId = "1",
                    AllowedGrantTypes = GrantTypes.ClientCredentials,
                    ClientSecrets = {
                        new Secret("1".Sha256())
                    },
                    AllowedScopes =  {
                        "grc:clients.read_all",
                        "grc:clients.read"
                    }
                },
                new Client
                {
                    ClientId = "7",
                    AllowedGrantTypes = GrantTypes.ClientCredentials,
                    ClientSecrets = {
                        new Secret("ea8".Sha256())
                    },
                    AllowedScopes =  {
                        "grc",
                        "grc:clients.read",
                        "grc:clients.read_all"
                    }
                }
            };
        }
    }
}
