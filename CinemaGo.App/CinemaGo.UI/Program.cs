using CinemaGo.Application.Services;
using CinemaGo.Core.Exceptions;
using CinemaGo.Core.Models;
using CinemaGo.Infrastructure.Repository;

var repository = new UserRepository();
var userService = new UserService(repository);

try
{
    var newUser = new User { Id = 1, Username = "Anakin", Email = "anakin@gmail.com" };

   
    userService.RegisterUser(newUser);
    Console.WriteLine("User registered successfully!");

    var foundUser = userService.GetUserByEmail("anakin@gmail.com");
    Console.WriteLine($"Found user: {foundUser.Username}");

    userService.RegisterUser(newUser);
}
catch (UserAlreadyExistsException ex)
{
    Console.WriteLine($"Custom Exception Caught: {ex.Message}");
}
catch (UserNotFoundException ex)
{
    Console.WriteLine($"Custom Exception Caught: {ex.Message}");
}
catch (Exception ex)
{
    Console.WriteLine($"General Exception Caught: {ex.Message}");
}