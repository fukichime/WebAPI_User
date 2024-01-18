using System.ComponentModel.DataAnnotations;

namespace UserPracticeWeb.API.Models.Users.DTOs
{
    public class UserSearchDtoRequest
    {
        public string Name { get; set; } = null!;

        public int? Age { get; set; }
    }
}
