using TutorialASP.Models;

namespace TutorialASP.Interfaces
{
    public interface IUserService
    {
        Task<List<User>> GetUsers();
        Task<User> GetById(Guid userId);
        Task<User> Create(CreateUserDto dto);
        Task<User> Update(Guid userId, UpdateUserDto dto);
        Task Delete(Guid userId);
    }
}
