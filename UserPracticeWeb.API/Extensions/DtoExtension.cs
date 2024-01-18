using System.Runtime.CompilerServices;
using UserPracticeWeb.API.Models.Users;
using UserPracticeWeb.API.Models.Users.DTOs;

namespace UserPracticeWeb.API.Extensions
{
    public static class DtoExtension
    {
        public static List<UserDto> ToDtoList(this List<User> users)
        {
            return users.Select(user => new UserDto
            {
                Id = user.Id,
                Name = user.Name,
                Surname = user.Surname,
                Age = user.Age
            }).ToList();
        }
    }
}
