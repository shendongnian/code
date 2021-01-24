    public class MyViewModel : BindableBase
    {
       private DelegateCommand _myCommand;
       public DelegateCommand MyCommand => _myCommand ?? (_myCommand = new DelegateCommand(Execute, CanExecute));
       //your method that will be executed
       private void Execute()
       {
           //Do sth.
       }
       //will be triggered through MyCommand.RaiseCanExecuteChanged()
       private bool CanExecute()
       {
           //you validating logic, e.g.
           return MyComplexObject != null;
       }
       private MyModel _myComplexObject;
       public MyModel MyComplexObject
       {
          get { return _myComplexObject; }
          set 
          {
              SetProperty(ref _myComplexObject, value);
              //Trigger the CanExecuteChanged Event
              MyCommand.RaiseCanExecuteChanged();
          }
       }
    }
