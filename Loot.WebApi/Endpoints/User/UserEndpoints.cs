using Loot.Application.Commands;

using MediatR;

namespace Loot.WebApi.Endpoints.User;

public static class UserEndpoints
{
    public static WebApplication RegisterUserEndpoints(this WebApplication app)
    {
        app.MapPost("/user", async (CreateUserCommand command, ISender mediator, CancellationToken cancellationToken) =>
        {
            var result = await mediator.Send(command, cancellationToken);
            return result.Match(user => Results.Ok(user), errors => Results.BadRequest(errors));
        });

        return app;
    }
}