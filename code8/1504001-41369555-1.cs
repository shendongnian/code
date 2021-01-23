    <Window.DataContext>
        <local:MainViewModel/>
    </Window.DataContext>
    
    <DataGrid ItemsSource="{Binding SniffMessage}"/>
     public class MainViewModel
    {
        public MainViewModel()
        {
            SniffMessage = new ObservableCollection<SnifferMessage>();
            SniffMessage.Add(new SnifferMessage
                    { Node = "one", Command = 1, Time = DateTime.Now, Payload = "1234", Metadata = "TTD" }
            );   
        }
        public ObservableCollection<SnifferMessage> SniffMessage { get; set; }
    }
