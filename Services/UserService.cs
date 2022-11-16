using Microsoft.EntityFrameworkCore;
using TutorialASP.Interfaces;
using TutorialASP.Models;

namespace TutorialASP.Services
{
    public class UserService : IUserService
    {
        private readonly DBContext _dbContext;
        public UserService(DBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<User>> GetUsers()
        {
            return await _dbContext.Users.ToListAsync();
        }
        public async Task<User> GetById(Guid userId)
        {
            var user = await _dbContext.Users.SingleOrDefaultAsync(x => x.Id == userId);
            if (user == null)
                throw new Exception("User not found");

            return user;
        }

        public async Task<User> Create(CreateUserDto dto)
        {
            var user = new User
            {
                Name = dto.Name,
                LastName = dto.LastName,
                Place = dto.Place,
            };

             _dbContext.Users.Add(user);
            await  _dbContext.SaveChangesAsync();
            return user;
        }
        public async Task<User> Update(Guid userId, UpdateUserDto dto)
        {
            var user = await GetById(userId);

            if(user == null)
                throw new Exception("User not found");

            if (dto.Name == null && dto.LastName == null && dto.Place == null )
                throw new Exception("You must update at least one property.");

            if (dto.Name != null)
                user.Name = dto.Name;

            if (dto.LastName!= null)
                user.LastName = dto.LastName;
            
            if(dto.Place != null)
                user.Place = dto.Place;

            await _dbContext.SaveChangesAsync();
            
            return user;
            
        }

        public async Task Delete(Guid userId)
        {
            _dbContext.Users.Remove(await GetById(userId));
        }

    }
}
