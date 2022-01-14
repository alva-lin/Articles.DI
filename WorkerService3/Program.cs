using WorkerService3;

IHost host = Host.CreateDefaultBuilder(args)
   .ConfigureServices(services =>
    {
        services.AddHostedService<Worker>();
        services.AddSingleton<ExampleService>();
        
        // 尝试注释（or 取消注释）下面的代码，形成不同组合，运行以查看输出结果
        services.AddSingleton<AService>();
        services.AddSingleton<BService>();
        // services.AddSingleton<CService>();
    })
   .Build();

await host.RunAsync();
