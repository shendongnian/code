    public class MainViewModel : INotifyPropertyChanged
    {
        public MainViewModel ()
        {
            StopSimulationCommand = new RelayCommand(arg => IsWebSocketOpened, arg => { CloseWebSocketChannel(); });
        }
        public RelayCommand StopSimulationCommand { get; private set; }
    }
