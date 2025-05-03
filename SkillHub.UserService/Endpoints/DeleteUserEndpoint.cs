using FastEndpoints;
using SkillHub.Application.Interfaces;

namespace SkillHub.UserService.Endpoints
{
    public class DeleteUserEndpoint : Endpoint<Guid>
    {
        private readonly IUserService _userService;
        public DeleteUserEndpoint(IUserService userService) => _userService = userService;

        public override void Configure()
        {
            Delete("/api/users/{id:guid}");
            AllowAnonymous();
        }

        public override async Task HandleAsync(Guid id, CancellationToken ct)
        {
            var deleted = await _userService.DeleteUserAsync(id);
            if (!deleted)
            {
                await SendNotFoundAsync();
                return;
            }
            await SendOkAsync();
        }
    }
}
