using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Collections;
using TravelLove.Models;
using TravelLove.Repository.RegisterUsersRepository;
using Serilog;

namespace TravelLove.Controllers
{


    [Route("api/[controller]")]
    [ApiController]
    // [ApiVersion("1")]
    public class RegisterUsersController : ControllerBase
    {
        private readonly TravelLoveDbContext _context;
        private readonly ILogger<RegisterUsersController> _logger;
        private readonly IRegisterUsersRepository _registerUsersRepository;


        public RegisterUsersController(TravelLoveDbContext context, ILogger<RegisterUsersController> logger,
            IRegisterUsersRepository registerUsersRepository)
        {
            _context = context;
            _logger = logger;
            _registerUsersRepository = registerUsersRepository;
        }



        // GET: api/RegisterUsers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RegisterUser>>> Getusers()
        {
            Log.Information("Getting all the users successfully.");
            //return Ok("u are using version 1");
            //return await _context.users.ToListAsync();
            return await _registerUsersRepository.Getusers();
        }

        // GET: api/RegisterUsers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<RegisterUser>> GetRegisterUser(int id)
        {
            //var registerUser = await _context.users.FindAsync(id);

            //if (registerUser == null)
            //{
            _logger.LogWarning("Getting all the users successfully.");
            //    return NotFound();
            //}

            //return registerUser;
            try
            {
                return await _registerUsersRepository.GetRegisterUser(id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return NotFound();
            }
        }

        // Authenticating user by their email and password
        // GET: api/RegisterUsers/sai123@gmail.com/sai123
        [HttpGet("{email}/{password}")]
        public async Task<ActionResult<RegisterUser>> GetRegisterUserByPwd(string email, string password)
        {
            //try
            //{
            //    return await _registerUsersRepository.GetRegisterUserByPwd(email, password);
            //}
            //catch (Exception ex)
            //{
            //    _logger.LogError(ex.Message);

            //    return NotFound();
            //}

            Hashtable err = new Hashtable();
            try
            {
                var authUser = await _registerUsersRepository.GetRegisterUserByPwd(email, password);
                if (authUser != null)
                {
                    return Ok(authUser);
                }
                else
                {
                    err.Add("Status", "Error");

                    err.Add("Message", "Invalid Credentials");

                    return Ok(err);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        //[Route("Login")]
        //public ActionResult Login(string email, string pwd)//([FromBody] User user)

        //{
        //    Hashtable err = new Hashtable();

        //    try
        //    {
        //        var result = _context.users.Where(x => x.Email.Equals(email) && x.Password.Equals(pwd)).FirstOrDefault();
        //        if (result != null) return Ok(result);
        //        else

        //        {

        //            err.Add("Status", "Error");

        //            err.Add("Message", "Invalid Credentials");

        //            return Ok(err);

        //        }
        //    }

        //    catch (Exception)

        //    {
        //        throw;

        //    }

        //    return null;
        //}

        // PUT: api/RegisterUsers/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.


        [HttpGet("check-email")]
        public async Task<IActionResult> CheckEmailExists([FromQuery] string email)
        {
            try
            {
                bool emailExists = await _registerUsersRepository.CheckEmailExistsAsync(email);
                return Ok(emailExists);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal Server Error");
            }
        }




        [HttpPut("{id}")]
        public async Task<IActionResult> PutRegisterUser(int id, RegisterUser registerUser)
        {
            //if (id != registerUser.UserId)
            //{
            //    return BadRequest();
            //}

            //_context.Entry(registerUser).State = EntityState.Modified;

            //try
            //{
            //    await _context.SaveChangesAsync();
            //}
            //catch (DbUpdateConcurrencyException)
            //{
            //    if (!RegisterUserExists(id))
            //    {
            //        return NotFound();
            //    }
            //    else
            //    {
            //        throw;
            //    }
            //}
            _logger.LogInformation("User updated successfully.");
            //return NoContent();

            if (id != registerUser.UserId)
            {
                return BadRequest();
            }

            _context.Entry(registerUser).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RegisterUserExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            _logger.LogWarning("Getting all the users successfully.");
            return NoContent();
        }

        // POST: api/RegisterUsers
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<RegisterUser>> PostRegisterUser(RegisterUser registerUser)
        {
            //_context.users.Add(registerUser);
            //await _context.SaveChangesAsync();
            _logger.LogWarning("Getting all the users successfully.");

            //return CreatedAtAction("GetRegisterUser", new { id = registerUser.UserId }, registerUser);
            await _registerUsersRepository.PostRegisterUser(registerUser);
            return CreatedAtAction("GetRegisterUser", new { id = registerUser.UserId }, registerUser);
        }

        // DELETE: api/RegisterUsers/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<RegisterUser>> DeleteRegisterUser(int id)
        {
            try
            {
                return await _registerUsersRepository.DeleteRegisterUser(id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return NotFound();
            }
        }

        private bool RegisterUserExists(int id)
        {
            return _registerUsersRepository.RegisterUserExists(id);
        }
    }
}