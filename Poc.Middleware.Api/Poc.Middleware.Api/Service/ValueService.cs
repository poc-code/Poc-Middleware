using Poc.Middleware.Api.Domain.Model;
using Poc.Middleware.Api.Service.Interface;

namespace Poc.Middleware.Api.Service
{
    public class ValueService : IValueService
    {
        public List<ValueModel> _lista;

        public ValueService()
        {
            _lista = new List<ValueModel>
            {
                new ValueModel{Name = "Value1"},
                new ValueModel{Name = "Value2"},
                new ValueModel{Name = "Value3"}
            };
        }

        public ValueModel? GetById(Guid guid)
        {
            return _lista.FirstOrDefault(x => x.GuiId.Equals(guid));
        }

        public List<ValueModel> GetAll() => _lista;
        public List<ValueModel> Add(ValueModel model)
        {
            _lista.Add(model);
            return _lista;
        }

        public ValueModel Update(ValueModel model)
        {
            if(model is null)
            {
                throw new InvalidOperationException("item não fornecido");
            }

            var rs = _lista.FirstOrDefault(x => x.GuiId.Equals(model.GuiId));
            if (rs is not null)
            {
                rs.GuiId = model.GuiId;
                rs.Name = model.Name;
            }
            else
            {
                throw new Exception("item não encontrado");
            };

            return model;
        }

        public List<ValueModel> Remove(ValueModel model)
        {
            var rs = _lista.FirstOrDefault(x => x.GuiId.Equals(model.GuiId));
            if(rs is not null)
            {
                _ = _lista.Remove(rs);

            }
            return _lista;
        }
    }
}
