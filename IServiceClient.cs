using System.Net.Http;
using System.Threading.Tasks;

namespace whater
{
    public interface IServiceClient
    {
        void Configure(string hostKey, IClientAuthentication clientAuthentication = null);
        Task<string> GetAsync(string uriKey);
        Task<T> GetAsync<T>(string uriKey);
        /// <summary>
        /// Please make sure to dispose of the response
        /// </summary>
        Task<HttpResponseMessage> GetRawAsync(string uriKey);

    }
}
