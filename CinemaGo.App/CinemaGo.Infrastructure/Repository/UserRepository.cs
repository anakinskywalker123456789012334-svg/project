using CinemaGo.Core.Interfaces;
using CinemaGo.Core.Models;
using System.IO;

namespace CinemaGo.Infrastructure.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly string _path = @"C:\Users\ASUS\Desktop\davaleba_\CinemaGo.App\CinemaGo.Infrastructure\Data\Data.txt";

        public User GetByEmail(string email)
        {
            if (!File.Exists(_path)) return null;

            var lines = File.ReadAllLines(_path);
            foreach (var line in lines)
            {
                var parts = line.Split(',');
                if (parts.Length >= 3 && parts[2].Equals(email, StringComparison.OrdinalIgnoreCase))
                {
                    return new User
                    {
                        Id = int.Parse(parts[0]),
                        Username = parts[1],
                        Email = parts[2]
                    };
                }
            }
            return null;
        }

        public void Add(User user)
        {
           
            string line = $"{user.Id},{user.Username},{user.Email}";
            File.AppendAllLines(_path, new[] { line });
        }
    }
}