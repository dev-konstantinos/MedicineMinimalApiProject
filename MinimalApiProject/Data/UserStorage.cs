using MinimalApiProject.Models;

namespace MinimalApiProject.Data
{
    public class UserStorage
    {
        public static List<UserModel> Users = new List<UserModel>
        {
            new UserModel { Username = "admin", PasswordHash = BCrypt.Net.BCrypt.HashPassword("admin123"), Role = "Admin" }
        };
    }
}
