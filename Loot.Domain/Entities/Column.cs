namespace Loot.Domain.Entities;

public class Column
{
    public Guid Id { get; set; }
    public required string Name { get; set; }
    public required Board Board { get; set; }
    public ICollection<TaskItem> Tasks { get; set; } = [];
}