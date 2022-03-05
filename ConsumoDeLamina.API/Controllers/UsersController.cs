using ConsumoDeLamina.API.Repositories.IRepository;
using ConsumoDeLamina.Entities.DTOs;
using ConsumoDeLamina.Entities.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConsumoDeLamina.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        protected ResponseDTO _response;
        public UsersController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
            _response = new ResponseDTO();
        }

        [HttpPost("Register")]
        public async Task<ActionResult> Register(UserDTO user)
        {
            var respuesta = await _userRepository.Register(
                new User
                {
                    UserName = user.UserName,
                    Email = user.Email
                }, user.Password);


            if (respuesta == -1)
            {
                _response.IsSuccess = false;
                _response.DisplayMessage = "Usuario ya existe";

                return BadRequest(_response);
            }

            if (respuesta == -500)
            {
                _response.IsSuccess = false;
                _response.DisplayMessage = "Error al crear el usuario";

                return BadRequest(_response);
            }
            _response.DisplayMessage = "Usuario creado con exito!";
            _response.Result = respuesta;
            return Ok(_response);
        }

        [HttpPost("Login")]
        public async Task<ActionResult> Login(UserDTO user)
        {
            var respuesta = await _userRepository.Login(user.Email, user.Password);

            if (respuesta == "nouser")
            {
                _response.IsSuccess = false;
                _response.DisplayMessage = "Usuario no existe";
                return BadRequest(_response);
            }
            if (respuesta == "wrongpassword")
            {
                _response.IsSuccess = false;
                _response.DisplayMessage = "Contraseña in correcta";
                return BadRequest(_response);
            }

            _response.Result = respuesta;
            _response.DisplayMessage = "Usuario conectado";
            return Ok(_response);
        }
    }
}
