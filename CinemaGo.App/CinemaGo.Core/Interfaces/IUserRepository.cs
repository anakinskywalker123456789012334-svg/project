using CinemaGo.Core.Models;

namespace CinemaGo.Core.Interfaces;

public interface IUserRepository
{
    User GetByEmail(string email);
    void Add(User user);
}