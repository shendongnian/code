    public class ViewModelBase : INotifyPropertyChanged
    {
       public event PropertyChangedEventHandler PropertyChanged;
    
       protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
       {
           PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
       }
       protected bool InDesignMode => DesignerProperties.GetIsInDesignMode(new DependecyObject());
    }
    public class ViewModel : ViewModelBase
    {
       private string[] _data;
    
       //ctor
       public ViewModel()
       {
           if (IsInDesignMode)
           {
               Data = new [] { "Visible", "In", "XAML", "Designer" }
           }
       }
    
       public string[] Data
       {
          get { return _data; }
          set { _data = value; OnPropertyChanged(); }
       }
    
       void SomeCommand_Execute()
       {
          string[] sampleData = new [] //this may come from the other viewmodel for example
          {
             "Item1", "Item2", "Items3";
          }
    
          Data = sampleData;
       }
    }
