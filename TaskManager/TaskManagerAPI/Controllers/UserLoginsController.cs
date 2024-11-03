using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TaskManagerAPI.Data;
using TaskManagerAPI.Entity;

namespace TaskManagerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserLoginsController : ControllerBase
    {
        private readonly TaskContext _context;

        public UserLoginsController(TaskContext context)
        {
            _context = context;
        }


       

        // POST: api/UserLogins
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<IActionResult> PostUserLogin(UserLogin userLogin)
        {
            try
            {
                var userReq = new UserRegister
                {
                    UserName = userLogin.UserName,
                    Email = userLogin.Email,
                    PasswordHash = BCrypt.Net.BCrypt.HashPassword(userLogin.Password),
                    Role = userLogin.Role
                };

                var data = await _context.UsersRegister.AddAsync(userReq);
                await _context.SaveChangesAsync();
                var res = new UserLogin
                {
                    Id = data.Entity.Id,
                    UserName = data.Entity.UserName,
                    Email = data.Entity.Email,
                    Role = data.Entity.Role
                };
                return Ok(res);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);

            }

        }


        [HttpPost("Login")]
        public async Task<IActionResult> LoginPage(LoginUser emailandPassword)
        {
            try
            {
                var UserLogin = await _context.UsersRegister.FirstOrDefaultAsync(f => f.Email == emailandPassword.Email);
                if (UserLogin == null)
                {
                    throw new Exception("User not found");
                };

                var IsValid = BCrypt.Net.BCrypt.Verify(emailandPassword.Password, UserLogin.PasswordHash);
                if (!IsValid) 
                {
                    throw new Exception("Wrong Password");
                };
                var res = new UserRegister
                {
                   Id = UserLogin.Id,
                   UserName = UserLogin.UserName,
                   Email = UserLogin.Email

                };
                return Ok(res);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);

            }

        }

    }
}
