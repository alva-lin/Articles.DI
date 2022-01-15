namespace WorkerService4;

public class Worker : BackgroundService
{
    private readonly IMyDependency _myDependency;

    private readonly IEnumerable<IMyDependency> _myDependencies;


    public Worker(IMyDependency myDependency, IEnumerable<IMyDependency> myDependencies)
    {
        _myDependency   = myDependency;
        _myDependencies = myDependencies;
    }


    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        // 最后一个注册的实现类型 MyDependency2
        _myDependency.Handler();

        Console.WriteLine();

        // 注册过的所有的实现，不会包含 MyDependency3
        foreach (var myDependency in _myDependencies)
        {
            myDependency.Handler();
        }
    }
}
