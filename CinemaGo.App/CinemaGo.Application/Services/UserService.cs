using CinemaGo.Core.Exceptions;
using CinemaGo.Core.Interfaces;
using CinemaGo.Core.Models;

namespace CinemaGo.Application.Services;

public class UserService
{
    private readonly IUserRepository _userRepository;

    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public void RegisterUser(User user)
    {
        var existingUser = _userRepository.GetByEmail(user.Email);
        if (existingUser != null)
        {
            throw new UserAlreadyExistsException($"User with email '{user.Email}' already exists.");
        }

        _userRepository.Add(user);
    }

    public User GetUserByEmail(string email)
    {
        var user = _userRepository.GetByEmail(email);
        if (user == null)
        {
            throw new UserNotFoundException($"User with email '{email}' was not found.");
        }

        return user;
    }
}