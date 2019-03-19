using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace whater
{
    class Program
    {
        static void Main(string[] args)
        {
            DoTest().Wait();
        }

        public static async Task DoTest() 
        {
            IServiceClient s = new ServiceClient(new ConfiguratorExample(), new HttpClient());
            ApiKeyAuthentication keyAuth = new ApiKeyAuthentication();

            s.Configure("example", keyAuth);

            var result = await s.GetAsync("testget");
            Console.WriteLine(result);
        }
    }
}
