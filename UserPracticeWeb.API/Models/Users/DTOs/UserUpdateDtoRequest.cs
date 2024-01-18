using System.ComponentModel.DataAnnotations;

namespace UserPracticeWeb.API.Models.Users.DTOs
{
    public class UserUpdateDtoRequest
    {
        public int Id { get; set; }

        [StringLength(10, MinimumLength = 3, ErrorMessage = "Kullanıcı adı 3 ile 10 karakter arasında olmalıdır.")]
        [Required(ErrorMessage = "Ad kısmı boş geçilemez!")]
        public string Name { get; set; } = null!;

        [StringLength(10, MinimumLength = 3, ErrorMessage = "Kullanıcı soyadı 3 ile 10 karakter arasında olmalıdır.")]
        [Required(ErrorMessage = "Soyadı kısmı boş geçilemez!")]
        public string Surname { get; set; } = null!;

        [Range(18, 64, ErrorMessage = "Kullanıcılar 18-64 yaş aralığında olmalıdır.")]
        [Required(ErrorMessage = "Kullanıcı yaş kısmı boş geçilemez!")]
        public int Age { get; set; }
    }
}
