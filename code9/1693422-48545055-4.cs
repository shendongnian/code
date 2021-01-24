    public interface IMyContractPtr 
    {
        void RunMe();
    }
    [ComVisible(true)]  // there are cleaner ways to expose COM-visible 
    public class MyClass : IMyContractPtr 
    {
       public void RunMe()
       {
           var form = new MainForm();
           form.ShowDialog(); // example
       }
    }
