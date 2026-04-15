using ErrorOr;

using FluentValidation;

using MediatR;

namespace Loot.Application.Commands;

public record ConfirmEmailCommand : IRequest<ErrorOr<Guid>>
{
    public Guid Id { get; init; }
    public required string Email { get; init; }
    public required string Token { get; init; }
}

public class ConfirmEmailCommandValidator : AbstractValidator<ConfirmEmailCommand>
{
    public ConfirmEmailCommandValidator()
    {
        RuleFor(options => options.Id)
            .NotEmpty();
        RuleFor(options => options.Email)
            .EmailAddress()
            .NotEmpty();
        RuleFor(options => options.Token)
            .NotEmpty();
    }
}