    <Window x:Class="WpfApplication1.Window1"
            xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
            xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
            xmlns:d="http://schemas.microsoft.com/expression/blend/2008"
            xmlns:mc="http://schemas.openxmlformats.org/markup-compatibility/2006"
            mc:Ignorable="d"
            Title="{Binding MyTitle, RelativeSource={RelativeSource Self}}" Height="300" Width="300">
        <StackPanel>
            <TextBox Text="{Binding MyTitle, UpdateSourceTrigger=PropertyChanged, RelativeSource={RelativeSource AncestorType=Window}}" />
        </StackPanel>
    </Window>
----------
    public partial class Window1 : Window, INotifyPropertyChanged
    {
        public Window1()
        {
            InitializeComponent();
        }
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
        private string _title;
        public string MyTitle
        {
            get { return _title; }
            set { _title = value; NotifyPropertyChanged(); }
        }
    }
