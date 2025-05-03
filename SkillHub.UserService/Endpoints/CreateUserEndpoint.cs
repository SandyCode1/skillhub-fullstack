using FastEndpoints;
using SkillHub.Application.DTOs;
using SkillHub.Application.Interfaces;
using SkillHub.Domain.Entities;

namespace SkillHub.UserService.Endpoints
{
    public class CreateUserEndpoint : Endpoint<UserDto, User>
    {
        private readonly IUserService _userService;
        public CreateUserEndpoint(IUserService userService) => _userService = userService;

        public override void Configure()
        {
            Post("/api/users");
            AllowAnonymous();
        }

        public override async Task HandleAsync(UserDto req, CancellationToken ct)
        {
            var user = new User
            {
                Id = Guid.NewGuid(),
                Name = req.Name,
                Email = req.Email,
                Phone = req.Phone
            };
            var created = await _userService.CreateUserAsync(user);
            await SendAsync(created);
        }
    }
}
