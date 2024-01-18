using UserPracticeWeb.API.Models.Users.DTOs;

namespace UserPracticeWeb.API.Models.Users
{
    public interface IUserRepository
    {
        List<User> GetList();

        User GetById(int id);

        List<User> SearchByName();

        List<User> SearchByAge();

        void Save(User user);

        void Update(User user);

        void Delete(int id);
        
    }
}
