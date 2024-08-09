using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using QCore.Domain.Events;

namespace QCore.Application.Common;

public class Dispatcher
{
    private readonly IServiceProvider _provider;
    private static List<Type> _eventHandlers = new List<Type>();

    public Dispatcher(IServiceProvider provider)
    {
        _provider = provider;
    }

    public static void RegisterEnventHandlers(Assembly assembly, IServiceCollection services)
    {
        var types = assembly.GetTypes()
                    .Where(x => x.GetInterfaces().Any(y => y.IsGenericType && y.GetGenericTypeDefinition() == typeof(IDomainEventHandler<>)))
                    .ToList();

        foreach (var type in types)
        {
            services.AddTransient(type);
        }

        _eventHandlers.AddRange(types);
    }

    public async Task DispatchAsync(ICommand command, CancellationToken cancellationToken = default)
    {
        Type type = typeof(ICommandHandler<>);
        Type[] typeArgs = { command.GetType() };
        Type handlerType = type.MakeGenericType(typeArgs);

        dynamic handler = _provider.GetService(handlerType);
        await handler.HandleAsync((dynamic)command, cancellationToken);
    }

    
}