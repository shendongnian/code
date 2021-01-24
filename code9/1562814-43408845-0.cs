    public class MainWindowViewModel : INotifyPropertyChanged
        {
    
            public MainWindowViewModel()
            {
                agents = new ObservableCollection<Agent>();
                LoadData();
            } 
        
        private void LoadData()
            {            
                agents.Add(new Agent { Id = 1, Category = "a" });
                agents.Add(new Agent { Id = 2, Category = "b" });
                agents.Add(new Agent { Id = 3, Category = "c" });
            }
        }
