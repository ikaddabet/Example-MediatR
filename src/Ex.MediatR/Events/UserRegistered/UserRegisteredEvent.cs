using MediatR;

namespace Ex.MediatR.Events.UserRegistered;

public class UserRegisteredEvent : INotification
{
    public string UserName { get; }

    public UserRegisteredEvent(string userName)
    {
        UserName = userName;
    }
}
