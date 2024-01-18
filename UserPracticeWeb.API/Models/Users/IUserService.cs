using UserPracticeWeb.API.Models.Users.DTOs;

namespace UserPracticeWeb.API.Models.Users
{
    public interface IUserService
    {
        List<UserDto> GetList();

        UserDto GetById(int id);

        List<UserDto> SearchByName(string name);

        List<UserDto> SearchByAge(int age);

        ResponseDto<int> Save(UserSaveDtoRequest request);

        void Update(UserUpdateDtoRequest request);

        void Delete(int id);
    }
}
