﻿using Core.Entities.Dtos;
using Core.Utilities.Results;
using Core.Utilities.Security.JWT;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity.Dtos.SystemStaff;

namespace Business.Abstract
{
    public interface IAuthService
    {
        IDataResult<User> Register(UserForRegisterDto userForRegisterDto, string password);
        IDataResult<User> RegisterList(List<UserForRegisterDto> usersForRegisterDto, string password);
        IDataResult<User> Login(UserForLoginDto userForLoginDto);
        IResult UserExists(string email);
        IDataResult<User> SystemStaffLogin(SystemStaffForLoginDto systemStaffForLoginDto);
        IDataResult<User> SystemStaffRegister(SystemStaffForRegisterDto systemStaffForRegisterDto);
        IDataResult<AccessToken> CreateAccessToken(User user);
    }
}
