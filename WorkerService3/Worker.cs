namespace WorkerService3;

public class Worker : BackgroundService
{
    private readonly ExampleService _exampleService;


    // 注入了 ExampleService 的实例，但是调用了它的哪个构造函数？ 
    public Worker(ExampleService exampleService)
    {
        _exampleService = exampleService;
    }


    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
    }
}
