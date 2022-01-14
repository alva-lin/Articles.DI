using WorkerService2;

IHost host = Host.CreateDefaultBuilder(args)
   .ConfigureServices(services =>
    {
        services.AddHostedService<Worker>();
        // 注册服务
        // services.AddSingleton<IMessageWriter, MessageWriter>();
        // 在注册服务时更改 ImessageWriter 的实现，无需修改每一处业务代码
        services.AddSingleton<IMessageWriter, LoggingMessageWriter>();
    })
   .Build();

await host.RunAsync();
