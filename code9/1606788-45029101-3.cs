    public delegate bool MyDel(object data);
    
    public class ViewModelBase
    {
       public MyDel SomeCommandExecuted;
    
       void SomeCommand_Execute()
       {
          string[] sampleData = new [] //this may come from the other viewmodel for example
          {
             "Item1", "Item2", "Items3";
          }
    
          MyDel handler = SomeCommandExecuted;
          if (handler != null)
          {
              handler(sampleData);
          }
       }
    }
