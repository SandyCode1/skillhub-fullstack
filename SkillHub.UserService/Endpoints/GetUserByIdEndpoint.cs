using FastEndpoints;
using SkillHub.Application.DTOs;
using SkillHub.Application.Interfaces;
using SkillHub.Domain.Entities;

namespace SkillHub.UserService.Endpoints
{
    public class GetUserByIdEndpoint : Endpoint<GetUserByIdRequest, User>
    {
        private readonly IUserService _userService;

        public GetUserByIdEndpoint(IUserService userService)
        {
            _userService = userService;
        }

        public override void Configure()
        {
            Get("/api/users/{id:guid}");
            AllowAnonymous();
        }

        public override async Task HandleAsync(GetUserByIdRequest req, CancellationToken ct)
        {
            var user = await _userService.GetUserByIdAsync(req.Id);
            if (user is null)
            {
                await SendNotFoundAsync();
                return;
            }
            await SendAsync(user);
        }
    }
}
