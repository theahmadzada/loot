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

        app.MapPost("/email", async (ConfirmEmailCommand command, ISender meadiator, CancellationToken cancellationToken) =>
        {
            var result = await meadiator.Send(command, cancellationToken);
            return result.Match(id => Results.Ok(id), errors => Results.BadRequest(errors));
        });
        
        return app;
    }
}