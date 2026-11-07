using MassTransit;
using OnlineShop.NotificationService.WebApi.Consumers;

var builder = WebApplication.CreateBuilder(args);

builder.Logging.AddFilter("MassTransit", LogLevel.Debug);
builder.Services.AddMassTransit(x =>
{
    x.AddConsumer<UserRegisteredConsumer>();

    x.UsingRabbitMq((context, cfg) =>
    {
        cfg.Host("localhost", "/", h =>
        {
            h.Username("guest");
            h.Password("guest");
        });

        cfg.ConfigureEndpoints(context);
    });
});

var app = builder.Build();

app.MapGet("/", () => "Notification service is running...");

app.Run();