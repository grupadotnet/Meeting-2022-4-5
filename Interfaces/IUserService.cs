using TutorialASP.Models;

namespace TutorialASP.Interfaces
{
    public interface IUserService
    {
        List<User> GetUsers();
        User GetById(Guid userId);
        User Create(CreateUserDto dto);
        User Update(Guid userId, UpdateUserDto dto);
        void Delete(Guid userId);
    }
}
