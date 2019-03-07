namespace whater
{
    public class ConfiguratorExample : IConfigurator
    {
        public HostConfig GetHost(string key)
        {
            if(key == "example")
            {
                return new HostConfig() {
                    Host = "https://example.com/"
                };
            }

            throw new System.NotImplementedException();
        }

        public string GetUri(string key)
        {
            if(key == "test")
            {
                return "/test/";
            }

            throw new System.NotImplementedException();
        }
    }
}
