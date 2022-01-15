using Microsoft.Extensions.DependencyInjection.Extensions;

using WorkerService4;

IHost host = Host.CreateDefaultBuilder(args)
   .ConfigureServices(services =>
    {
        services.AddHostedService<Worker>();
        
        // 同时注册一个接口的多种实现
        services.AddSingleton<IMyDependency, MyDependency1>();
        services.AddSingleton<IMyDependency, MyDependency2>();
        
        // TryAdd 如果接口已被注册过，不会再注册
        services.TryAddSingleton<IMyDependency, MyDependency3>();
    })
   .Build();

await host.RunAsync();
