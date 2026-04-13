using ErrorOr;
using FluentValidation;
using Loot.Application.Dtos;
using MediatR;

namespace Loot.Application.Commands;

public record CreateUserCommand : IRequest<ErrorOr<UserDto>>
{
    public required string FirstName { get; init; }
    public required string LastName { get; init; }
    public required string Email { get; init; }
    public required string Password { get; init; }
    public required string ConfirmPassword { get; init; }
}

public class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
{
    public CreateUserCommandValidator()
    {
        RuleFor(user => user.FirstName)
            .MaximumLength(15)
            .NotEmpty();
        RuleFor(user => user.LastName)
            .MaximumLength(15)
            .NotEmpty();
        RuleFor(user => user.Email)
            .EmailAddress()
            .NotEmpty();
        RuleFor(user => user.Password)
            .NotEmpty()
            .MinimumLength(8);
        RuleFor(user => user.ConfirmPassword)
            .Equal(user => user.Password)
            .WithMessage("Password and confirm password do not match.");
    }
}