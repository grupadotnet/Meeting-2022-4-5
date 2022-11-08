using TutorialASP.Interfaces;
using TutorialASP.Models;

namespace TutorialASP.Services
{
    public class UserService : IUserService
    {
        private static List<User> Users = new List<User>
        {
                new User
                {
                    Id = Guid.NewGuid(),
                    Name = "Jan",
                    LastName = "Kowalski",
                    Place = "Kraków"
                },
                new User
                {
                    Id = Guid.NewGuid(),
                    Name = "John",
                    LastName = "Doe",
                    Place = "USA"
                }
    };
        public List<User> GetUsers()
        {
            return Users;
        }
        public User GetById(Guid userId)
        {
            return Users.Find((user) => user.Id == userId);
        }

        public User Create(CreateUserDto dto)
        {
            var user = new User
            {
                Id = Guid.NewGuid(),
                Name = dto.Name,
                LastName = dto.LastName,
                Place = dto.Place,
            };

            Users.Add(user);

            return user;
        }
        public User Update(Guid userId, UpdateUserDto dto)
        {
            var user = GetById(userId);

            if (dto.Name == null && dto.LastName == null && dto.Place == null )
                throw new Exception("You must update at least one property.");

            if (dto.Name != null)
                user.Name = dto.Name;

            if (dto.LastName!= null)
                user.LastName = dto.LastName;
            
            if(dto.Place != null)
                user.Place = dto.Place;
            return user;
            
        }

        public void Delete(Guid userId)
        {
            Users.Remove(GetById(userId));
        }

    }
}
