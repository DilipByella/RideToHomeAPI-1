using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System;
using TravelLove.Models;
using TravelLove.Repository.RegisterUsersRepository;

namespace TravelLove.Repository.RegisterUsersRepository
{
    public class RegisterUsersRepository : IRegisterUsersRepository
    {
        private readonly TravelLoveDbContext _context;
        private readonly ILogger<RegisterUsersRepository> _logger;

        public RegisterUsersRepository(TravelLoveDbContext context, ILogger<RegisterUsersRepository> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<ActionResult<IEnumerable<RegisterUser>>> Getusers()
        {
            _logger.LogInformation("Getting all the users successfully.");
            return await _context.Users.ToListAsync();
        }

        public async Task<ActionResult<RegisterUser>> GetRegisterUser(int id)
        {
            var registerUser = await _context.Users.FindAsync(id);
            if (registerUser == null)
            {
                throw new NullReferenceException("Sorry, no user found with this id " + id);
            }
            else
            {
                return registerUser;
            }
        }

        public async Task<ActionResult<RegisterUser>> GetRegisterUserByPwd(string email, string password)
        {
                var user = await _context.Users.FirstOrDefaultAsync(x => x.Email == email && x.Password == password);
                if (user == null)
                {
                    return null;
                    //return new NullReferenceException("Sorry, no user found with this credentials.");
                }
                //else
                //{
                //    return user;
                //}
            
            
            return user;
        }
        public async Task<bool> CheckEmailExistsAsync(string email)
        {
            // Implement logic to check if the email exists in the database
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
            return user != null; // Return true if the email exists, false otherwise
        }
        public async Task<ActionResult<RegisterUser>> PostRegisterUser(RegisterUser registerUser)
        {
            _context.Users.Add(registerUser);
            await _context.SaveChangesAsync();
            _logger.LogInformation("User created successfully.");

            return registerUser;
        }

        public async Task<ActionResult<RegisterUser>> DeleteRegisterUser(int id)
        {
                var registerUser = await _context.Users.FindAsync(id);

                if (registerUser == null)
                {
                return null;    
                //throw new NullReferenceException("Sorry, no user found with this id " + id);
                }
                //else
                //{
                    _context.Users.Remove(registerUser);
                    await _context.SaveChangesAsync();
                    _logger.LogInformation("User deleted successfully.");

                    return registerUser;
                //}
           
        }

        public bool RegisterUserExists(int id)
        {
            return _context.Users.Any(e => e.UserId == id);
        }
    }
}