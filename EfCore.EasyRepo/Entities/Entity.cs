using Microsoft.EntityFrameworkCore;

namespace EasyEF.Entities;

[PrimaryKey("Id")]
public abstract class Entity : IEntity
{
    public Guid Id { get; set; } = Ulid.NewUlid().ToGuid();
}

public interface IEntity
{
    public Guid Id { get; set; }
}