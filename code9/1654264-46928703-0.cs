    <Image x:Name="img" Width="30" Height="30" Source="Resources/Images/chat_file_attach.png">
        <Image.Style>
            <Style TargetType="{x:Type Image}">
                <Setter Property="Visibility" Value="Collapsed" />
                <Style.Triggers>
                    <DataTrigger Binding="{Binding AttachStat}" Value="True">
                        <Setter Property="Visibility" Value="Visible" />
                    </DataTrigger>
                </Style.Triggers>
            </Style>
        </Image.Style>
    </Image>
----------
    img.DataContext = new YourClass();
    ...
    public class YourClass : INotifyPropertyChanged
    {
        private bool _attachStat;
        public bool AttachStat
        {
            get
            {
                return _attachStat;
            }
            set
            {
                _attachStat = value;
                NotifyPropertyChanged();
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
