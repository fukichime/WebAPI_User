using System.Xml.Linq;
using AutoMapper;
using UserPracticeWeb.API.Models.Users.DTOs;

namespace UserPracticeWeb.API.Models.Users
{
    public class UserService : IUserService
    {
        private readonly IUserRepository userRepository;
        private readonly IMapper mapper;

        //constructors
        public UserService(IMapper mapper)
        {
            this.mapper = mapper;
            userRepository = new UserRepository();
        }

        public List<UserDto> GetList()
        {
            var users = userRepository.GetList();

            var userDtos = mapper.Map<List<UserDto>>(users);

            return userDtos;
        }

        public UserDto GetById(int id) 
        {
            var user = userRepository.GetById(id);

            if(user == null)
            {
                throw new Exception();
                //expection
            }
            var userDto = mapper.Map<UserDto>(user);
            return userDto;
        }

        #region SearchDTO version
        //public List<UserDto> SearchUsers(UserSearchDtoRequest searchRequest)
        //{

        //    var users = userRepository.GetList();

        //    if(!string.IsNullOrEmpty(searchRequest.Name))
        //    {
        //        users = users.Where(u => u.Name.Contains(searchRequest.Name, StringComparison.OrdinalIgnoreCase)).ToList();
        //    }

        //    else if (searchRequest.Age.HasValue)
        //    {
        //        users = users.Where(u => u.Age == searchRequest.Age.Value).ToList();
        //    }

        //   var searchResults =  mapper.Map<List<UserDto>>(users);
        //    return searchResults;
        //} 
        #endregion

        public List<UserDto> SearchByName(string name)
        {
            var users = userRepository.GetList();
            users = users.Where(u => u.Name.Contains(name, StringComparison.OrdinalIgnoreCase)).ToList();
            var searchResults = mapper.Map<List<UserDto>>(users);
            return searchResults; 
        }

        public List<UserDto> SearchByAge(int age)
        {
            var users = userRepository.GetList();
            users = users.Where(u => u.Age == age).ToList();
            var searchResults = mapper.Map<List<UserDto>>(users);
            return searchResults;
        }

        public ResponseDto<int> Save(UserSaveDtoRequest request)
        {
            var id = new Random().Next(1, 100);

            var user = new User
            {
                Id = id,
                Name = request.Name,
                Surname = request.Surname,
                Age = request.Age
            };

            userRepository.Save(user);
            return ResponseDto<int>.Success(id);
        }



        public void Update(UserUpdateDtoRequest request)
        {
            User user = new User
            {
                Id = request.Id,
                Name = request.Name,
                Surname = request.Surname,
                Age = request.Age
            };
            userRepository.Update(user);
        }

        public void Delete(int id)
        {
            userRepository.Delete(id);
        }
    }
}
