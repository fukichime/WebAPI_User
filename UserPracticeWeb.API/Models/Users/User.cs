namespace UserPracticeWeb.API.Models.Users
{
    public class User
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public string Surname { get; set; } = null!;

        public int Age { get; set; }
    }
}
