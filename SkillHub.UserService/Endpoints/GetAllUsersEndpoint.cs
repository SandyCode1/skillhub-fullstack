using FastEndpoints;
using Microsoft.EntityFrameworkCore.Query;
using SkillHub.Application.Interfaces;
using SkillHub.Domain.Entities;

namespace SkillHub.UserService.Endpoints
{
    public class GetAllUsersEndpoint : EndpointWithoutRequest<IEnumerable<User>>
    {
        private readonly IUserService _userService;
        public GetAllUsersEndpoint(IUserService userService) => _userService = userService;

        public override void Configure()
        {
            Get("/api/users");
            AllowAnonymous();
        }

        public override async Task HandleAsync(CancellationToken ct)
        {
            var users = await _userService.GetAllUsersAsync();
            if (!users.Any())
            {
                await SendNotFoundAsync();
                return;
            }
            await SendAsync(users);
        }
    }
}
