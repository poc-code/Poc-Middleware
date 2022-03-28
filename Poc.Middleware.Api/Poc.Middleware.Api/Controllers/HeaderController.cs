using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Poc.Middleware.Api.Domain.Response;

namespace Poc.Middleware.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HeaderController : ControllerBase
    {
        /// <summary>
        /// Middleware que verificar se foi passado alguma credencial no cabeçalho
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Get()
        {
            string customHeader = string.Empty;
            if (Request.Headers.TryGetValue("x-api-key", out var traceValue))
            {
                customHeader = traceValue;
            }
            ResponseDefaultModel response = new ResponseDefaultModel
            {
                Data = new { credential = customHeader },
                Message = "Verificando credenciais"
            };
            return Ok(response);
        }
    }
}
