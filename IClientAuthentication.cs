using System.Net.Http;

namespace whater
{
    public interface IClientAuthentication
    {
        void Apply(HttpRequestMessage request, HostConfig hostConfig);
    }
}
