namespace WorkerService3;

/*
 * 拥有多个构造函数的 ExampleService，在被注入的时候，会调用哪个构造函数？
 *
 * 规则：
 *      1. 构造函数所需的参数实例必须是已经注册过的；
 *      2. 在上述条件上，选择最多参数的构造参数；
 *      3. 如果同时存在两个（或更多个）满足上述条件的构造函数，则会抛出异常；
 */
public class ExampleService
{
    public ExampleService() => Console.WriteLine("空的构造函数"); 


    public ExampleService(AService aService) => 
        Console.WriteLine("单参数构造函数：AService");


    public ExampleService(AService aService, BService bService) => 
        Console.WriteLine("双参数构造函数：AService, BService");


    public ExampleService(AService aService, CService cService) => 
        Console.WriteLine("双参数构造函数：AService, CService");
}

public class AService
{
    public AService() => Console.WriteLine("AService 实例化");
}

public class BService
{
    public BService() => Console.WriteLine("BService 实例化");
}

public class CService
{
    public CService() => Console.WriteLine("CService 实例化");
}
