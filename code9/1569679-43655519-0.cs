    <DataTemplate DataType="{x:Type tt:FunctionDataType}" 
                  x:Key="TimeLineFunctionDataTemplate">
        <Border x:Name="DataContainer"
            BorderThickness="0.3"
            BorderBrush="Black" 
            CornerRadius="2" 
            Margin="0,20,0,10" 
            Height="50" 
            Background="{Binding BgBrush}">
            <StackPanel Orientation="Vertical">
                <TextBlock Text="{Binding Path=Name}" FontWeight="Bold"/>
                <TextBlock Text="{Binding Path=StartTime.TotalMilliseconds, StringFormat={}{0} ms}" FontSize="8"/>
                <TextBlock Text="{Binding Path=EndTime.TotalMilliseconds, StringFormat={}{0} ms}" FontSize="8"/>
            </StackPanel>
        </Border>
    </DataTemplate>
----------
    public class FunctionDataType : ITimeLineDataItem, INotifyPropertyChanged
    {
        public TimeSpan? StartTime { get; set; }
        public TimeSpan? EndTime { get; set; }
        public Boolean TimelineViewExpanded { get; set; }
        public String Name { get; set; }
        private Brush _bgBrush;
        public Brush BgBrush
        {
            get { return _bgBrush; }
            set { _bgBrush = value; NotifyPropertyChanged(); }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
