using Poc.Middleware.Api.Domain.Model;
using Poc.Middleware.Api.Service.Interface;

namespace Poc.Middleware.Api.Service
{
    public class CredentialService : ICredentialService
    {
        private readonly List<ClientkeyModel> _listAllowedHeaders;

        public CredentialService()
        {
            _listAllowedHeaders = new List<ClientkeyModel>
            {
                new ClientkeyModel("75556906-c0d3-4b7b-917d-11cdbae15733","Client01"),
                new ClientkeyModel("c40c0d18-2a24-421d-988d-6b2f03fde244","Client02"),
                new ClientkeyModel("d6699167-57e4-46fe-b388-6287eb738987","Client03")
            };
        }

        public ClientkeyModel GetById(string key)
        {
            if (string.IsNullOrEmpty(key))
            {
                throw new ArgumentNullException($"Cliente não informado");
            }

            return _listAllowedHeaders.FirstOrDefault(x => x.ClientSecret.Equals(key));
        }
    }
}
