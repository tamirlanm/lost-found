using System.ComponentModel.DataAnnotations;

namespace LostAndFound.Api.Features.Items.Create;

public sealed class CreateFoundItemRequest
{
    [Required, StringLength(150)] public string Name { get; init; } = string.Empty;
    [Required, StringLength(1024)] public string Description { get; init; } = string.Empty;

    [Required, EnumDataType(typeof(ItemCategory))]
    public ItemCategory? Category { get; init; }
    
    [Required, StringLength(100)]
    public string Cabinet { get; init; } = string.Empty;
    
    [Required]
    public DateTimeOffset? FoundAt { get; init; }
}