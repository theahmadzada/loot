using ErrorOr;

using Loot.Application.Commands;

using MediatR;

namespace Loot.Application.Handlers;

public class ConfirmEmailCommandHandler : IRequestHandler<ConfirmEmailCommand, ErrorOr<Guid>>
{
    public Task<ErrorOr<Guid>> Handle(ConfirmEmailCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}