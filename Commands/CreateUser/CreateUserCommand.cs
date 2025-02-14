using MediatR;

namespace Ex.MediatR.Commands.CreateUser;

public class CreateUserCommand : IRequest<string>
{
    public string UserName { get; }

    public CreateUserCommand(string userName)
    {
        UserName = userName;
    }
}
