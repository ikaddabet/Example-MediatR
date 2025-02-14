using MediatR;

namespace Ex.MediatR.Events.UserRegistered;

public class UserRegisteredEventHandler : INotificationHandler<UserRegisteredEvent>
{
    public Task Handle(UserRegisteredEvent notification, CancellationToken cancellationToken)
    {
        // Handle the event (e.g., print a welcome message)
        Console.WriteLine($"Event Handled: Welcome, {notification.UserName}!");
        return Task.CompletedTask;
    }
}
