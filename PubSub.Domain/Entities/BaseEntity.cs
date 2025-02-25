using System.ComponentModel.DataAnnotations;

namespace PubSub.Domain.Entities;

public class BaseEntity<T>
{
    public BaseEntity(T id)
    {
        Id = id;
    }

    [Required]
    public T Id { get; }
}
