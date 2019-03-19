using System.Net.Http;
using System.Threading.Tasks;

namespace whater
{
    public class ServiceClient : IServiceClient
    {
        protected readonly HttpClient client;
        private readonly IConfigurator configurator;
        private HostConfig hostConfig = null;
        private IClientAuthentication authorizer = null;

        public ServiceClient(IConfigurator configurator, HttpClient client)
        {
            this.configurator = configurator;
            this.client = client;
        }

        public void Configure(string hostKey, IClientAuthentication clientAuthentication = null)
        {
            hostConfig = configurator.GetHost(hostKey);
            authorizer = clientAuthentication;
        }

        public async Task<string> GetAsync(string uriKey)
        {
            var uri = configurator.GetUri(uriKey);

            using(var request = new HttpRequestMessage(HttpMethod.Get, hostConfig.Host + uri))
            {
                ApplyAuth(request);

                using (var response = await Send(request))
                {
                    response.EnsureSuccessStatusCode();

                    return await response.Content.ReadAsStringAsync();
                }
            }
        }

        public async Task<T> GetAsync<T>(string uriKey)
        {
            var uri = configurator.GetUri(uriKey);

            using(var request = new HttpRequestMessage(HttpMethod.Get, hostConfig.Host + uri))
            {
                ApplyAuth(request);

                using (var response = await Send(request))
                {
                    response.EnsureSuccessStatusCode();

                    return await response.Content.ReadAsAsync<T>();
                }
            }
        }

        public async Task<HttpResponseMessage> GetRawAsync(string uriKey)
        {
            var uri = configurator.GetUri(uriKey);

            using(var request = new HttpRequestMessage(HttpMethod.Get, hostConfig.Host + uri))
            {
                ApplyAuth(request);

                return await Send(request);
            }
        }

        protected virtual async Task<HttpResponseMessage> Send(HttpRequestMessage request) 
        {
            return await this.client.SendAsync(request);
        }

        protected void ApplyAuth(HttpRequestMessage request)
        {
            if (authorizer != null)
            {
                authorizer.Apply(request, hostConfig);
            }
        }
    }
}
