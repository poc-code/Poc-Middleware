namespace Poc.Middleware.Api.Domain.Model
{
    public class ClientkeyModel
    {
        public ClientkeyModel( string key, string name)
        {
            ClientName = name;
            ClientSecret = key;
        }
        public string ClientName { get; init; }
        public string ClientSecret { get; init; }
    }
}
