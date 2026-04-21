using Loot.Application.Commands;

using MediatR;

namespace Loot.WebApi.Endpoints.Board;

public static class BoardEndpoints
{
    public static WebApplication RegisterBoardEndpoints(this WebApplication app)
    {
        app.MapPost("/board", async (CreateBoardCommand command, ISender mediator, CancellationToken cancellationToken) =>
        {
            var result = await mediator.Send(command, cancellationToken);
            return result.Match(value => Results.Ok(value), errors => Results.BadRequest(errors));
        });
        
        return app;
    }
}