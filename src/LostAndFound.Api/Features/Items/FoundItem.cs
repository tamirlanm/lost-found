namespace  LostAndFound.Api.Features.Items;

public class FoundItem
{
    public Guid Id { get; private set; }
    public Guid UserFoundId { get; private set; }
    public string Name { get; private set; } = string.Empty;
    public string Description { get; private set; } = string.Empty;
    public string Category { get; private set; } = string.Empty;
    public string Cabinet { get; private set; } = string.Empty;
    public FoundItemStatus Status { get; private set; }
    public DateTimeOffset FoundStatus { get; private set; }
    public DateTime CreatedAt { get; private set; }
}
