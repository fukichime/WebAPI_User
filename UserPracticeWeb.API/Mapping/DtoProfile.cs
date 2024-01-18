using AutoMapper;
using UserPracticeWeb.API.Models.Users;
using UserPracticeWeb.API.Models.Users.DTOs;

namespace UserPracticeWeb.API.Mapping
{
    public class DtoProfile : Profile
    {
        public  DtoProfile() 
        {
            CreateMap<User, UserDto>().ReverseMap();
        }
    }
}
