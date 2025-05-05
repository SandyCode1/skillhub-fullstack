using FastEndpoints;
using SkillHub.Application.Interfaces;
using SkillHub.UserService.Requests;

namespace SkillHub.UserService.Endpoints
{
    public class DeleteUserEndpoint : Endpoint<DeleteUserRequest>
    {
        private readonly IUserService _userService;
        public DeleteUserEndpoint(IUserService userService) => _userService = userService;

        public override void Configure()
        {
            Delete("/api/users/{id:guid}");
            AllowAnonymous();
        }

        public override async Task HandleAsync(DeleteUserRequest req, CancellationToken ct)
        {
            var deleted = await _userService.DeleteUserAsync(req.Id);
            if (!deleted)
            {
                await SendNotFoundAsync();
                return;
            }
            await SendOkAsync();
        }
    }
}
