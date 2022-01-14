using WorkerService2;

IHost host = Host.CreateDefaultBuilder(args)
   .ConfigureServices(services =>
    {
        services.AddHostedService<Worker>();
        // 注册服务
        services.AddSingleton<IMessageWriter, MessageWriter>();
    })
   .Build();

await host.RunAsync();
