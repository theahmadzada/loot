using Loot.Application.Commands;

using MediatR;

namespace Loot.WebApi.Endpoints.Board;

public static class BoardEndpoints
{
    public static WebApplication RegisterBoardEndpoints(this WebApplication app)
    {
        app.MapPost("/", (CreateBoardCommand command, ISender mediator, CancellationToken cancellationToken) =>
        {

        });
        
        return app;
    }
}