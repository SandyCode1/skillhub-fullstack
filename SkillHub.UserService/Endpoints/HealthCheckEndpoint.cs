using FastEndpoints;

namespace SkillHub.UserService.Endpoints
{
    public class HealthCheckEndpoint : EndpointWithoutRequest
    {
        public override void Configure()
        {
            Get("/health");
            AllowAnonymous(); // No auth needed
            Summary(s => {
                s.Summary = "Basic health check endpoint";
                s.Description = "Returns OK if the service is running.";
            });
        }

        public override async Task HandleAsync(CancellationToken ct)
        {
            await SendOkAsync(new { status = "Healthy" }, ct);
        }
    }

}
