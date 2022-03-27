using Microsoft.AspNetCore.Mvc;
using Poc.Middleware.Api.Domain.Model;
using Poc.Middleware.Api.Service.Interface;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Poc.Middleware.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        public IValueService _service;

        public ValuesController(IValueService service)
        {
            _service = service;
        }


        /// <summary>
        /// Busca todos os itens da lista
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult<List<ValueModel>> Get()
        {
            return Ok(_service.GetAll());
        }

        /// <summary>
        /// Buscar o item por id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public ActionResult<ValueModel> Get(Guid id)
        {
            return Ok(_service.GetById(id));
        }

        /// <summary>
        /// Adiciona um novo valor a lista
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult<List<ValueModel>> Post([FromBody] ValueModel request)
        {
            return Ok(_service.Add(request));
        }

        /// <summary>
        /// Atualiza o item da lista
        /// </summary>
        /// <param name="id"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public ActionResult<ValueModel> Put(Guid id, [FromBody] ValueModel request)
        {
            if(_service.GetById(id) is not null)
            {
                return NoContent();
            }

            return Ok(_service.Update(request));
        }

        /// <summary>
        /// Remove o item da lista
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public ActionResult<List<ValueModel>> Delete(Guid id)
        {
            var model = _service.GetById(id);

            if (model is null)
            {
                return NoContent();
            }

            return Ok(_service.Remove(model));
        }
    }
}
