using MassTransit;
using OnlineShop.NotificationService.WebApi.Contracts;

namespace OnlineShop.NotificationService.WebApi.Consumers;

public class UserRegisteredConsumer : IConsumer<UserRegistered>
{
    private readonly ILogger<UserRegisteredConsumer> _logger;

    public UserRegisteredConsumer(ILogger<UserRegisteredConsumer> logger)
    {
        _logger = logger;
    }

    public Task Consume(ConsumeContext<UserRegistered> context)
    {
        UserRegistered message = context.Message;

        _logger.LogInformation(new string('=', 40));
        _logger.LogInformation("EMAIL SENT to {Email}", message.Email);
        _logger.LogInformation("Hello, {FirstName}! Welcome to OnlineShop!", message.FirstName);
        _logger.LogInformation("User ID: {UserId}, Registered at: {RegisteredAt}", message.UserId, message.RegisteredAt);
        _logger.LogInformation("========================================");

        return Task.CompletedTask;
    }
}