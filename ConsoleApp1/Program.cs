// See https://aka.ms/new-console-template for more information

using ConsoleApp1;

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using IHost host = Host.CreateDefaultBuilder(args)
   .ConfigureServices(services =>
    {
        services.AddTransient<OperationLogger>()
           .AddTransient<ITransientOperation, DefaultOperation>()
           .AddScoped<IScopedOperation, DefaultOperation>()
           .AddSingleton<ISingletonOperation, DefaultOperation>();
    })
   .Build();

ExemplifyScoping(host.Services, "Scope 1");
ExemplifyScoping(host.Services, "Scope 2");

await host.RunAsync();


static void ExemplifyScoping(IServiceProvider services, string scope)
{
    using IServiceScope serviceScope = services.CreateScope();
    IServiceProvider    provider     = serviceScope.ServiceProvider;

    var logger = provider.GetRequiredService<OperationLogger>();
    logger.LogOperations($"{scope}: Call 1 ...");
    Console.WriteLine();

    logger = provider.GetRequiredService<OperationLogger>();
    logger.LogOperations($"{scope}: Call 2 ...");
    Console.WriteLine();
}
