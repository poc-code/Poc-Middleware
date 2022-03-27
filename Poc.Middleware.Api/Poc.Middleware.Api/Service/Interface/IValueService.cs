using Poc.Middleware.Api.Domain.Model;

namespace Poc.Middleware.Api.Service.Interface
{
    public interface IValueService
    {
        ValueModel? GetById(Guid guid);
        List<ValueModel> GetAll();
        List<ValueModel> Add(ValueModel model);
        ValueModel Update(ValueModel model);
        List<ValueModel> Remove(ValueModel model);
    }
}
