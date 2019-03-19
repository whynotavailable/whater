using System.Collections.Generic;

namespace whater
{
    public class ConfiguratorExample : IConfigurator
    {
        public HostConfig GetHost(string key)
        {
            if(key == "example")
            {
                var config = new Dictionary<string, string>();
                config.Add("api-key", "myKwyy");

                return new HostConfig() {
                    Host = "https://httpbin.org",
                    ConfigData = config
                };
            }

            throw new System.NotImplementedException();
        }

        public string GetUri(string key)
        {
            if(key == "testget")
            {
                return "/get";
            }

            throw new System.NotImplementedException();
        }
    }
}
