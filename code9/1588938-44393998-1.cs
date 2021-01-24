    interface IMyState {};
    public class StateA:IMyState{ public string PropA{get;set;} };
    public class StateD:IMyState{ public string PropD{get;set;} };
    ...
    IMyState _test= new StateD(...);
    switch (_test)
    {
        case StateA a: 
            Console.WriteLine($"Case A ok. {a.PropA}");
            break;
        case StateD d: 
            Console.WriteLine($"Case D ok. {d.PropD}");
            break;
        default :
            throw new InvalidOperationException("Where's my state ?");
    }
