namespace  LostAndFound.Api.Features.Items;
using System;
public class FoundItem
{
    public Guid Id { get; private set; }
    public Guid UserFoundId { get; private set; }
    public string Name { get; private set; } = string.Empty;
    public string Description { get; private set; } = string.Empty;
    public ItemCategory Category { get; private set; }
    public string Cabinet { get; private set; } = string.Empty;
    public FoundItemStatus Status { get; private set; }
    public DateTimeOffset FoundStatus { get; private set; }
    public DateTimeOffset CreatedAt { get; private set; }
    public string? PhotoKey {get;set;}

    private FoundItem()
    { }

    public FoundItem(
        Guid userFoundId,
        string name,
        string description,
        ItemCategory category,
        string cabinet,
        DateTime foundStatus,
        // DateTime createdAt,
        string? photoKey)
    {
        Id = Guid.NewGuid();
        UserFoundId = userFoundId;
        Name = name;
        Description = description;
        Category = category;
        Cabinet = cabinet;
        FoundStatus = foundStatus.ToUniversalTime();
        CreatedAt = DateTimeOffset.UtcNow;
        PhotoKey = photoKey;
    }
}
