using Loot.Domain.Entities;

namespace Loot.Application.Dtos;

public record UserDto
{
    public Guid Id { get; init; }
    public required string FirstName { get; init; }
    public required string LastName { get; init; }
    public required string Email { get; init; }

    public static explicit operator UserDto(User user)
    {
        return new UserDto
        {
            Id = user.Id,
            Email = user.Email!,
            FirstName = user.FirstName,
            LastName = user.LastName
        };
    }
}