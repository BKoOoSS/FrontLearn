using FrontLearn_1.Models;
using FrontLearn_1.Services;
using FrontLearn_1.Data;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase
{
    private readonly UserService _userService;

    public UserController(UserService userService)
    {
        _userService = userService;
    }

    [HttpPost("register")]
    public async Task<IActionResult> AddUser([FromBody] User user)
    {
        if (user == null || string.IsNullOrEmpty(user.Name) || string.IsNullOrEmpty(user.Email) || string.IsNullOrEmpty(user.Password))
            return BadRequest("Invalid user data.");

        await _userService.AddUserAsync(user);
        return Ok("User added successfully.");
    }

    public record LoginRequest(string Email, string Password);
    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginRequest request)
    {
        if (string.IsNullOrEmpty(request.Email) || string.IsNullOrEmpty(request.Password))
            return BadRequest("Invalid login data.");

        var user = await _userService.GetUserByEmailAsync(request.Email);
        if (user == null || user.Password != request.Password)
            return Unauthorized("Invalid email or password.");

        return Ok("Login successful.");
    }

    

    [HttpGet("{id}")]
    public async Task<IActionResult> GetUserById(int id)
    {
        var user = await _userService.GetUserByIdAsync(id);
        if (user == null)
            return NotFound("User not found.");

        return Ok(user);
    }

    [HttpGet("all")]
    public async Task<IActionResult> GetAllUsers()
    {
        var users = await _userService.GetAllUsersAsync();
        return Ok(users);
    }

    [HttpPut("update")]
    public async Task<IActionResult> UpdateUser([FromBody] User user)
    {
        if (user == null || user.Id <= 0 || string.IsNullOrEmpty(user.Name) || string.IsNullOrEmpty(user.Email) || string.IsNullOrEmpty(user.Password))
            return BadRequest("Invalid user data.");

        var updated = await _userService.UpdateUserAsync(user);
        if (!updated)
            return NotFound("User not found.");

        return Ok("User updated successfully.");
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteUser(int id)
    {
        var deleted = await _userService.DeleteUserAsync(id);
        if (!deleted)
            return NotFound("User not found.");

        return Ok("User deleted successfully.");
    }
}
