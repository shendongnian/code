    public class MyAggregateService
    {
        IFirstService FirstService { get; }
        ISecondService SecondService { get; }
        IThirdService ThirdService { get; }
        IFourthService FourthService { get; }
    
         public MyAggregateService (IFirstService first, ISecondService second, IThirdService third, IFourthService fourth)
         {
             FirstService = first;
             SecondService = second;
             ThirdService = third;
             FourthService = fourth;
         }
    }
    // then register that in the container
    services.AddTransient<MyAggregateService>();
    // and depend on it in the controller
    public MyController (MyAggregateService aggregateService)
    { … }
