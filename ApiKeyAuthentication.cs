using System.Net.Http;

namespace whater
{
    public class ApiKeyAuthentication : IClientAuthentication
    {
        public void Apply(HttpRequestMessage request, HostConfig hostConfig)
        {
            request.Headers.Add("api-key", hostConfig.ConfigData["api-key"]);
        }
    }
}
