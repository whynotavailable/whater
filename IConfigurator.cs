namespace whater
{
    public interface IConfigurator
    {
        string GetUri(string key);
        HostConfig GetHost(string key);
    }
}
