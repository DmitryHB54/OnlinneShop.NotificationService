namespace OnlineShop.Shared.Contracts;

public record UserRegistered(
    Guid UserId,
    string Email,
    string? FirstName,
    string? LastName,
    DateTime RegisteredAt);