using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SalaoDeBeleza.Model;
using SalaoDeBeleza.Model.Data;
using SalaoDeBeleza.Repository;

namespace SalaoDeBeleza.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ColaboradorController : ControllerBase
    {
        private readonly IColaboradorRepository _repo;

        public ColaboradorController(IColaboradorRepository repo)
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
        public async Task<IActionResult> Create([FromBody] Colaborador colaborador)
        {
            if (colaborador == null)
            {
                return BadRequest("Dados de colaborador inválidos.");
            }

            var result = await this._repo.Create(colaborador);

            if (result != null)
            {
                return Ok(result);
            }
            else
            {
                return StatusCode(500, "Falha ao criar colaborador. Verifique os dados e tente novamente.");
            }
        }


        [HttpPut("Update")]
        public async Task<IActionResult> Update([FromBody] Colaborador cliente)
        {
            var _result = await this._repo.Update(cliente);
            return Ok(_result);
        }

        [HttpDelete("Remove/{id}")]
        public async Task<IActionResult> Remove(int id)
        {
            var _result = await this._repo.Remove(id);
            return Ok(_result);
        }

    }
}

