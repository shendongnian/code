            public class ViewModel : INotifyPropertyChanged
            {
            
                public SetupViewModel SetupViewModel 
                {
                    get { return m_SetupViewModel; }
                    set
                    {
                        m_SetupViewModel = value;
                        OnPropertyChanged();
                    }
                }
            
                public ManualControlViewModel ManualControlViewModel
                {
                    get { return m_ManualControlViewModel; }
                    set
                    {
                        m_ManualControlViewModel = value;
                        OnPropertyChanged();
                    }
                }
            
                public event PropertyChangedEventHandler PropertyChanged;
            
                private void OnConnect(object obj)
                {
                    _client = new TcpClient(IP_ADDRESS, PORT);
                    _client.Client.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.KeepAlive, true);
                    _master = ModbusIpMaster.CreateIp(_client);
                    Connected = _client.Connected;
            
                    ManualControlViewModel = new ManualControlViewModel(_master);
                    SetupViewModel = new SetupViewModel(_master);
            
                    StartReadingInfo();
                }
            
                private void OnPropertyChanged([CallerMemberName] string PropertyName = "")
                {
                    var handler = PropertyChanged;
                    if (handler != null) handler(this, new PropertyChangedEventArgs(PropertyName));
                }
            
                private ManualControlViewModel m_ManualControlViewModel;
                private SetupViewModel m_SetupViewModel;
            }
