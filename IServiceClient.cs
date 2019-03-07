using System.Threading.Tasks;

namespace whater
{
    public interface IServiceClient
    {
        void Configure(string hostKey, IClientAuthentication clientAuthentication = null);
        Task<string> GetAsync(string uriKey);
        Task<T> GetAsync<T>(string uriKey);
        Task<byte[]> GetBinaryAsync(string uriKey);

    }
}
