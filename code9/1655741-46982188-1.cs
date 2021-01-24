    public class MyAggregateService
    {
        public IFirstService FirstService { get; }
        public ISecondService SecondService { get; }
        public IThirdService ThirdService { get; }
        public IFourthService FourthService { get; }
    
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
