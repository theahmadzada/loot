namespace Loot.Domain.Entities;

public class TaskItem
{
    public Guid Id { get; set; }
    public required string Name { get; set; }
    public string? Description { get; set; }
    public required Column Column { get; set; }
    public DateTimeOffset? DueTo { get; set; }
    public DateTimeOffset CreatedDate { get; set; } = DateTimeOffset.Now;
    public DateTimeOffset? UpdatedDate { get; set; }
}