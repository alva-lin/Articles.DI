namespace WorkerService4;

public interface IMyDependency
{
    void Handler();
}

public class MyDependency1 : IMyDependency
{
    public void Handler()
    {
        Console.WriteLine($"{typeof(MyDependency1)} handler...");
    }
}

public class MyDependency2 : IMyDependency
{
    public void Handler()
    {
        Console.WriteLine($"{typeof(MyDependency2)} handler...");
    }
}

public class MyDependency3 : IMyDependency
{
    public void Handler()
    {
        Console.WriteLine($"{typeof(MyDependency3)} handler...");
    }
}
