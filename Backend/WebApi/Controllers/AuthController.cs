﻿using Business.Abstract;
using Core.Entities.Dtos;
using Entity.Dtos.SystemStaff;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("login")]
        public ActionResult Login(UserForLoginDto userForLoginDto)
        {
            var userToLogin = _authService.Login(userForLoginDto);
            if (!userToLogin.Success)
            {
                return BadRequest(userToLogin);
            }

            var result = _authService.CreateAccessToken(userToLogin.Data);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpPost("register")]
        public ActionResult Register(UserForRegisterDto userForRegisterDto)
        {
            var userExists = _authService.UserExists(userForRegisterDto.Email);
            if (!userExists.Success)
            {
                return BadRequest(userExists);
            }

            var registerResult = _authService.Register(userForRegisterDto, userForRegisterDto.Password);
            if (registerResult.Success)
            {
                var result = _authService.CreateAccessToken(registerResult.Data);
                return Ok(result);
            }

            return BadRequest(registerResult);
        }

        [HttpPost("registerList")]
        public ActionResult RegisterList(List<UserForRegisterDto> usersForRegisterDto)
        {
            var registerResult = _authService.RegisterList(usersForRegisterDto, usersForRegisterDto[0].Password);
            if (registerResult.Success)
            {
                var result = _authService.CreateAccessToken(registerResult.Data);
                return Ok(result);
            }

            return BadRequest(registerResult);
        }

        [HttpPost("resgisterStaff")]
        public ActionResult RegisterStaff(SystemStaffForRegisterDto staffForCreateDto)
        {
            var staffExists = _authService.UserExists(staffForCreateDto.Email);
            if (!staffExists.Success)
            {
                return BadRequest(staffExists);
            }

            var registerResult = _authService.SystemStaffRegister(staffForCreateDto);
            if (registerResult.Success)
            {
                var result = _authService.CreateAccessToken(registerResult.Data);
                return Ok(result);
            }

            return BadRequest(registerResult);
        }

        [HttpPost("loginStaff")]
        public ActionResult LoginStaff(SystemStaffForLoginDto staffForLoginDto)
        {
            var staffToLogin = _authService.SystemStaffLogin(staffForLoginDto);
            if (!staffToLogin.Success)
            {
                return BadRequest(staffToLogin);
            }

            var result = _authService.CreateAccessToken(staffToLogin.Data);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }
    }
}
