# MediatR Example

This is an example of a .NET 9 console application demonstrating the use of MediatR for handling commands and events with Dependency Injection.

## Table of Contents

- [Introduction](#introduction)
- [Prerequisites](#prerequisites)
- [Project Structure](#project-structure)
- [MediatR Concepts](#mediatr-concepts)
  - [Publish](#publish)
  - [Send](#send)
- [Folder Structure](#folder-structure)
- [Setup & Installation](#setup--installation)
- [Usage](#usage)

## Introduction

In this example, we will demonstrate how to use **MediatR** in a console application. MediatR is a simple library that facilitates the **Mediator Pattern**, helping to decouple components in an application by using requests and handlers to communicate.

The application will show:
- How to **publish events** (fire-and-forget) using `Publish`.
- How to **send commands** and receive responses using `Send`.

## Prerequisites

Before running the example, ensure that you have the following:
- [.NET 9 SDK](https://dotnet.microsoft.com/download/dotnet/9.0) installed.
- A code editor such as Visual Studio or Visual Studio Code.

## Project Structure

The project is organized as follows:

```
/MediatRConsoleApp
│
├── /Commands
│   ├── CreateUserCommand.cs
│   └── CreateUserCommandHandler.cs
│
├── /Events
│   ├── UserRegisteredEvent.cs
│   └── UserRegisteredEventHandler.cs
│
├── Program.cs
```

- **Commands**: Contains all the command classes (requests that modify state) and their respective handlers.
- **Events**: Contains all event classes (notifications that do not return a result) and their respective handlers.
- **Program.cs**: Entry point for the console application, responsible for setting up MediatR and publishing/sending requests.
- **appsettings.json** (optional): Used for application configuration (if needed).

## MediatR Concepts

### Publish

The `Publish` method is used for **events** (or notifications). These are "fire-and-forget" messages that do not return any result.

**Example:**
- **Use Case**: Notify all parts of the system that a new user has registered.

```csharp
await mediator.Publish(new UserRegisteredEvent("JohnDoe"));
```

**Handler:** Responds to the event and performs some action.

```csharp
public class UserRegisteredEventHandler : INotificationHandler<UserRegisteredEvent>
{
    public Task Handle(UserRegisteredEvent notification, CancellationToken cancellationToken)
    {
        Console.WriteLine($"Event Handled: Welcome, {notification.UserName}!");
        return Task.CompletedTask;
    }
}
```

### Send

The `Send` method is used for **commands** or queries where you expect a response. These are typically used when you need to modify state or retrieve data.

**Example:**
- **Use Case**: Create a new user and return a confirmation message.

```csharp
var result = await mediator.Send(new CreateUserCommand("JaneDoe"));
Console.WriteLine(result);
```

**Handler:** Processes the command and returns a result.

```csharp
public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, string>
{
    public Task<string> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        return Task.FromResult($"User {request.UserName} created successfully!");
    }
}
```

## Folder Structure

Here's a breakdown of the folder structure:

```
/MediatRConsoleApp
│
├── /Commands
│   ├── CreateUserCommand.cs           # Represents a command to create a user
│   └── CreateUserCommandHandler.cs    # Handles the CreateUserCommand and returns a result
│
├── /Events
│   ├── UserRegisteredEvent.cs         # Represents an event triggered when a user registers
│   └── UserRegisteredEventHandler.cs  # Handles the UserRegisteredEvent and performs actions
│
├── Program.cs                         # Entry point for the application, resolves DI, publishes events, and sends commands
└── appsettings.json (optional)        # Configuration file (optional)
```

- **Commands** are actions that modify state or perform tasks.
- **Events** are notifications sent throughout the system when something important happens (without expecting a return value).
- **Handlers** process both commands and events.

## Setup & Installation

**Clone the repository (if applicable):**

```bash
git clone https://github.com/ikaddabet/Example-MediatR.git
cd Example-MediatR
```

**restore dependencies:**

```bash
dotnet restore
```

**Build the project:**

```bash
dotnet build
```

**Run the application:**

```bash
cd  src\Ex.MediatR
dotnet run
```

## Usage

### Running the Example

Once the application is running, you will see the following in the console:

```
Publishing UserRegisteredEvent...
Event Handled: Welcome, JohnDoe!
Sending CreateUserCommand...
Command Result: User JaneDoe created successfully!
```

This example demonstrates:

- **Publishing an event**: The `UserRegisteredEvent` is published, and the handler prints a message to the console.
- **Sending a command**: The `CreateUserCommand` is sent, and the handler returns a success message indicating the user was created.

### Adding More Commands/Events

- To add more **commands**, create a new class in the `/Commands` folder and a corresponding handler.
- To add more **events**, create a new class in the `/Events` folder and a corresponding handler.

## Conclusion

This is a simple example of how to use MediatR in a .NET 9 console application to decouple your logic and handle commands and events in a clean, maintainable way. This pattern helps improve testability and scalability for larger applications.

Feel free to extend this example with more complex logic, additional handlers, or services as needed!

## License

This project is licensed under the MIT License - see the LICENSE file for details.
