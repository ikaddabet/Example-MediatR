using MediatR;
using System.Reflection;

var builder = Host.CreateDefaultBuilder()
    .ConfigureServices((hostContext, services) =>
    {
        // Register MediatR with the current assembly
        services.AddMediatR(options => options.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

        // Register other services if necessary
    });

var app = builder.Build();

// Resolve the IMediator from the DI container
var mediator = app.Services.GetRequiredService<IMediator>();

// Publish a domain event (fire-and-forget)
Console.WriteLine("Publishing UserRegisteredEvent...");
await mediator.Publish(new Events.UserRegisteredEvent("JohnDoe"));

// Send a command that expects a response
Console.WriteLine("Sending CreateUserCommand...");
var result = await mediator.Send(new Commands.CreateUserCommand("JaneDoe"));
Console.WriteLine($"Command Result: {result}");

// Wait for the event to be handled
Console.ReadLine();