    public class ShellViewModel : Conductor<object> 
    {
      private readonly IMefDependencyContainer _container;      
      public ShellViewModel(IMefDependencyContainer container) {
        _container = container;   
      }     
       
      public void ShowCreateRecord()
      {
        ActivateItem(_container.Resolve<CreateRecordViewModel>());
      }
    }
