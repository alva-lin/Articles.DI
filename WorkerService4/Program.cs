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
        // IMyDependency 已经被注册过
        services.TryAddSingleton<IMyDependency, MyDependency3>();

        // TryAddEnumerable 如果接口的同一种实现被注册过，则不会重复注册
        // IMyDependency -> MyDependency4，这个没有被注册过，所以可以成功注册
        var descriptor = new ServiceDescriptor(
            typeof(IMyDependency),
            typeof(MyDependency4),
            ServiceLifetime.Singleton);
        services.TryAddEnumerable(descriptor);
        
        // MyDependency2 被注册过两次
        // 那么在获取 IEnumerable<IMyDependency> 时
        // MyDependency2 类型的实例会有两个
        services.AddSingleton<IMyDependency, MyDependency2>();
    })
   .Build();

await host.RunAsync();
