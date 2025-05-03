using FastEndpoints;
using SkillHub.Application.Interfaces;
using SkillHub.Domain.Entities;

namespace SkillHub.UserService.Endpoints
{
    public class UpdateUserEndpoint : Endpoint<User>
    {
        private readonly IUserService _userService;
        public UpdateUserEndpoint(IUserService userService) => _userService = userService;

        public override void Configure()
        {
            Put("/api/users");
            AllowAnonymous();
        }

        public override async Task HandleAsync(User req, CancellationToken ct)
        {
            var updated = await _userService.UpdateUserAsync(req);
            if (!updated)
            {
                await SendNotFoundAsync();
                return;
            }
            await SendOkAsync();
        }
    }
}
