    public class Model
    {
       public event EventHandler SomethingHappened; // e.g. you notification
    }
    
    public class ViewModel
    {
       public ViewModel(Model model)
       {
           model.SomethingHappend += SomethingHappend;
       }
       void Model_SomethingHappend(object sender, EventArgs e)
       {
          DoSomething();
       }
       void CleanUp()
       {
           /*
              In order to prevent memoryleak:
              If you subscribe to event of an object you have not created in this class 
              (Model.SomethingHappend in this case), you should also unsubscribe. 
              Otherwise model instance will keep reference to ViewModel instance. 
           */
           model.SomethingHappend -= SomethingHappend;
       }
    }
