using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SalaoDeBeleza.Model;
using SalaoDeBeleza.Model.Data;
using SalaoDeBeleza.Repository;

namespace SalaoDeBeleza.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServicoController : ControllerBase
    {
        private readonly IServicoRepository _repo;

        public ServicoController(IServicoRepository repo)
        {
            _repo = repo;
        }

        [HttpGet("GetAll")]

        public async Task<IActionResult>GetAll()
        {
            var _list = await _repo.GetAll();
            if(_list != null)
            {
                return Ok(_list);
            }
            else
            {
                return NotFound("Não foi encontrado nenhum registro"); 
            }
        }
        [HttpGet("GetByTipo/{tipo}")]
        public async Task<IActionResult> GetByTipo(int tipo)
        {
            var _list = await this._repo.GetByTipo(tipo);
            if (_list != null)
            {
                return Ok(_list);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpGet("GetbyId/{id}")]
        public async Task<IActionResult> GetbyId(int id)
        {
            var _list = await this._repo.GetbyId(id);
            if (_list != null)
            {
                return Ok(_list);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromBody] Servico servico)
        {
            var _result = await this._repo.Create(servico);
            return Ok(_result);
        }

        [HttpPut("Update")]
        public async Task<IActionResult> Update([FromBody] Servico servico, int code)
        {
            var _result = await this._repo.Update(servico, code);
            return Ok(_result);
        }

        [HttpDelete("Remove")]
        public async Task<IActionResult> Remove(int code)
        {
            var _result = await this._repo.Remove(code);
            return Ok(_result);
        }
    }
}

