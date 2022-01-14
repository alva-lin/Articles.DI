namespace ConsoleApp1;

public interface IOperation
{
    string OperationId { get; }
}

public interface ITransientOperation : IOperation
{
}

public interface IScopedOperation : IOperation
{
}

public interface ISingletonOperation : IOperation
{
}

public class DefaultOperation
    : ITransientOperation,
        IScopedOperation,
        ISingletonOperation
{
    // 随机一个 Guid，取最后 4 个字符
    public string OperationId { get; } = Guid.NewGuid().ToString()[^4..];
}
