using MediatR;

namespace Ex.MediatR.Commands.CreateUser;

public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, string>
{
    public Task<string> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        // Simulate creating a user
        return Task.FromResult($"User {request.UserName} created successfully!");
    }
}
