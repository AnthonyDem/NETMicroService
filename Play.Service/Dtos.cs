using System;
using System.ComponentModel.DataAnnotations;

namespace Play.Service.Dots
{
    public record ItemDto(Guid Id, string Name, string Description, decimal Price, DateTimeOffset CreatedDate);

    public record CreateItemDto([Required] string Name, string Description,[Range (0, 1200)] decimal Price);

    public record UpdateItemDto([Required] string Name, string Description,[Range(0, 1200)] decimal Price);
}

namespace System.Runtime.CompilerServices
{
    internal static class IsExternalInit { }
}