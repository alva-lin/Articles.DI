namespace WorkerService2;

public class Worker : BackgroundService
{
    // 松耦合，只依赖接口，不依赖具体实现。Worker 类不负责初始化成员
    private readonly IMessageWriter _messageWriter;


    // 从构造函数传递注入具体的实例，将其赋值给 _messageWriter 成员
    public Worker(IMessageWriter messageWriter)
    {
        _messageWriter = messageWriter;
    }


    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            _messageWriter.Write($"Worker running at: {DateTimeOffset.Now}");
            await Task.Delay(1000, stoppingToken);
        }
    }
}

public interface IMessageWriter
{
    void Write(string message);
}

public class MessageWriter : IMessageWriter
{
    public void Write(string message)
    {
        Console.WriteLine($"MessageWriter.Write(message: \"{message}\")");
    }
}
