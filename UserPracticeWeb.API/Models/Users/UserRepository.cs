using System.Net.Cache;

namespace UserPracticeWeb.API.Models.Users
{
    public class UserRepository : IUserRepository
    {
        private static readonly List<User> users = new List<User>();

        public UserRepository()
        {
            if (users.Count == 0)
            {
                //user examples
                users.Add(new User { Id = 1, Name = "userName 1", Surname = "UserSurname 1", Age = 21 });
                users.Add(new User { Id = 2, Name = "userName 2", Surname = "UserSurname 2", Age = 22 });
                users.Add(new User { Id = 3, Name = "userName 3", Surname = "UserSurname 3", Age = 23 });
            }
        }

        public List<User> GetList()
        {
            return users;
        }

        public User GetById (int id) 
        {
            {
                return users.FirstOrDefault(user => user.Id == id);
            }
        }

        public List<User> SearchByName()
        {
            return users;
        }

        public List<User> SearchByAge()
        {
            return users;
        }

        public void Save(User user) => users.Add(user);

        public void Update(User user)
        {
            var userToUpdateIndex = users.FindIndex(user => user.Id == user.Id);

            users[userToUpdateIndex].Name = user.Name;
            users[userToUpdateIndex].Surname = user.Surname;
            users[userToUpdateIndex].Age = user.Age;
        }

        public void Delete(int id)
        {
            var userToDeleteIndex = users.FindIndex(user => user.Id == user.Id);

            users.RemoveAt(userToDeleteIndex);
        }
    }
}
