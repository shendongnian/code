    public class MyModel : BindableBase
    {
       private string Name _name;
       public Name 
       {
         get { return _name; }
         set { SetProperty(ref _name, value); }
       }
    }
