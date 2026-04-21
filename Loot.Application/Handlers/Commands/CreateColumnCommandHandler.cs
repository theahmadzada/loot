using ErrorOr;

using Loot.Application.Commands;
using Loot.Application.Dtos;
using Loot.Domain.Entities;
using Loot.Domain.Enums;
using Loot.Infrastructure.DbContext;

using MediatR;

using Microsoft.EntityFrameworkCore;

namespace Loot.Application.Handlers.Commands;

public class CreateColumnCommandHandler : IRequestHandler<CreateColumnCommand, ErrorOr<ColumnDto>>
{
    private readonly LootDbContext _context;

    public CreateColumnCommandHandler(LootDbContext context)
    {
        _context = context;
    }

    public async Task<ErrorOr<ColumnDto>> Handle(CreateColumnCommand request, CancellationToken cancellationToken)
    {
        var board = await _context.Boards.FirstOrDefaultAsync(x => x.Id == request.BoardId, cancellationToken: cancellationToken);
        if (board == null)
        {
            return Error.NotFound("Board.NotFound", "Board not found");
        }

        var member = await _context.Members.FirstOrDefaultAsync(x => x.Board == board && 
                                                               x.UserId == request.UserId, cancellationToken);
        if (member == null)
        {
            return Error.NotFound("Member.NotFound", "Member not found");
        }

        if (member.Role != BoardRole.Owner)
        {
            return Error.Forbidden("Member.Forbidden", "Member not allowed");
        }
        
        var column = new Column() { Name = request.Name, Board = board };
        var result = await _context.Columns.AddAsync(column, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);

        return new ColumnDto() { Id = result.Entity.Id, Name = result.Entity.Name };
    }
}