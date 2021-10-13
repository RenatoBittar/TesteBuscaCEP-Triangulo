using Infrastructure.Entidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace API.Controllers
{
    [ApiController]
    [Route("api/cep")]
    public class CepController : ControllerBase
    {
        private readonly CepService _cepService;

        public CepController(CepService cepService)
        {
            _cepService = cepService;
        }

        [HttpGet]
        public IEnumerable<CEP> BuscarTodos()
        {
            return _cepService.Listar();
        }

        // GET api/cep/5
        [HttpGet("{cep}")]
        public IActionResult Buscar(string cep)
        {
            try
            {
                var ret = _cepService.Buscar(cep);
                return Ok(ret);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        // GET api/cep/5
        [HttpGet("uf/{uf}")]
        public IActionResult BuscarUf(string uf)
        {
            try
            {
                var ret = _cepService.BuscarUf(uf);
                return Ok(ret);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
