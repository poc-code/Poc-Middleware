using Poc.Middleware.Api.Domain.Model;

namespace Poc.Middleware.Api.Service.Interface
{
    public interface ICredentialService
    {
        ClientkeyModel GetById(string key);
    }
}
