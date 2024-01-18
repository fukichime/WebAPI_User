using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using UserPracticeWeb.API.Models.Users;
using UserPracticeWeb.API.Models.Users.DTOs;

namespace UserPracticeWeb.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService userService;
        
        public UsersController(IMapper mapper) 
        {
            userService = new UserService(mapper);
        }

        [HttpGet]
        public IActionResult GetList()
        {
            return Ok(userService.GetList());   
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            return Ok(userService.GetById(id));
        }

        [HttpGet("search/Name/{age?}")]
        public IActionResult SearchUsers(string name)
        {
            var foundUser = userService.SearchByName(name);
            return Ok(foundUser);
        }

        [HttpGet("search/Age/{age?}")]
        public IActionResult SearchByAge(int age)
        {
            var foundUser = userService.SearchByAge(age);
            return Ok(foundUser);
        }

        [HttpPost]
        public IActionResult Save(UserSaveDtoRequest request)
        {
            var result = userService.Save(request);
            return Created("", result);
        }

        [HttpPut]
        public IActionResult Update(UserUpdateDtoRequest request)
        {
            userService.Update(request);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            userService.Delete(id);
            return NoContent();
        }
    }
}
