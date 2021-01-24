    public interface IMyClass {
        string prop1 {get; set;}
        string prop2 {get; set;}  
    }
    public class MyClass : IMyClass
    { 
        public string prop1 {get; set;}  
        public string prop2 {get; set; }   
    }
    public class OtherClass : IMyClass
    {   
        public string prop1 {get; set;}  
        public string prop2 {get; set;}  
    }
    private ObservableCollection<MyClass> _myselectedItems = new ObservableCollection<MyClass>();
    public ObservableCollection<IMyClass> MySelectedItems
    {  
        get{return _myselectedItem;}
        set{_myselectedItem = value;}  
    }
    private ObservableCollection<OtherClass> _otherselectedItems = new ObservableCollection<OtherClass>();
    public ObservableCollection<OtherClass> OtherSelectedItems
    {  
        get{return _otherselectedItem;}
        set{_otherselectedItem = value;}   
    }
    public GenericMethod(ObservableCollection<IMyClass> anySelectedItems)
    {
        if (anySelectedItems[0].prop1 != "Hello")
        {   // do something
        }
    }
