using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ConsumoDeLamina.Data;
using ConsumoDeLamina.Entities.Models;
using ConsumoDeLamina.API.Repositories.IRepository;
using ConsumoDeLamina.Entities.DTOs;
using Microsoft.AspNetCore.Authorization;

namespace ConsumoDeLamina.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ConsumoDeLaminaController : ControllerBase
    {
        private readonly IConsumoDeLaminaRepository _consumoDeLaminaRepository;
        protected ResponseDTO _response;


        public ConsumoDeLaminaController(IConsumoDeLaminaRepository consumoDeLaminaRepository)
        {
            _consumoDeLaminaRepository = consumoDeLaminaRepository;
            _response = new ResponseDTO();
        }

        // GET: api/ConsumoDeLamina
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ConsumoDeLamin>>> GetConsumoDeLamina()
        {
            try
            {
                var cl = await _consumoDeLaminaRepository.Get();
                _response.Result = cl;
                _response.DisplayMessage = "Listado de consumos de lamina";
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.DisplayMessage = "Error al obtener la informacion!";
                _response.ErrorMessages = new List<string> { ex.ToString() };
            }

            return Ok(_response);
        }

        // GET: api/ConsumoDeLamina/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ConsumoDeLamin>> GetConsumoDeLamin(int id)
        {
            var cl = await _consumoDeLaminaRepository.GetById(id);
            if (cl == null)
            {
                _response.IsSuccess = false;
                _response.DisplayMessage = "Consumo de lamina no existe" + id;
                return NotFound();
            }
            _response.Result = cl;
            _response.DisplayMessage = "Consumo de lamina";
            return Ok(_response);
        }

        // PUT: api/ConsumoDeLamina/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutConsumoDeLamin(int id, ConsumoDeLaminDTO consumoDeLaminDTO)
        {
            try
            {
                ConsumoDeLaminDTO cl = await _consumoDeLaminaRepository.CreateUpdate(consumoDeLaminDTO);
                _response.Result = cl;
                return Ok(cl);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.DisplayMessage = "Error al actualizar!";
                _response.ErrorMessages = new List<string> { ex.ToString() };
                return BadRequest(_response);
            }
        }

        // POST: api/ConsumoDeLamina
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ConsumoDeLamin>> PostConsumoDeLamin(ConsumoDeLaminDTO consumoDeLaminDTO)
        {
            try
            {
                ConsumoDeLaminDTO cl = await _consumoDeLaminaRepository.CreateUpdate(consumoDeLaminDTO);
                _response.Result = cl;
                return CreatedAtAction("GetConsumoDeLamin", new { id = cl.Id }, _response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.DisplayMessage = "Error al grabar el registro!";
                _response.ErrorMessages = new List<string> { ex.ToString() };
                return BadRequest(_response);
            }
        }

        // DELETE: api/ConsumoDeLamina/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteConsumoDeLamin(int id)
        {
            try
            {
                bool estaEliminado = await _consumoDeLaminaRepository.Delete(id);
                if (estaEliminado)
                {
                    _response.Result = estaEliminado;
                    _response.DisplayMessage = "Registro eliminado";
                    return Ok(_response);
                }
                else
                {
                    _response.IsSuccess = false;
                    _response.DisplayMessage = "Error al eliminar el registro!";
                    return BadRequest(_response);
                }
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string> { ex.ToString() };
                return BadRequest(_response);
            }
        }
    }
}
