    public class MyObject : INotifyPropertyChanged
    {
        private double height;
        [Browsable(true)]
        public double Height
        {
            get
            {
                return height;
            }
            set
            {
                height = value;
                Test = height.ToString(); //this refreshes Test
            }
        }
        private string _test;
        public string Test
        {
            get { return _test; }
            set { _test = value; NotifyPropertyChanged(); }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
----------
    <xctk:PropertyGrid x:Name="_propertyGrid" Width="450" Margin="10" AutoGenerateProperties="False">
        <xctk:PropertyGrid.PropertyDefinitions>
            <xctk:PropertyDefinition TargetProperties="Height" />
            <xctk:PropertyDefinition TargetProperties="Test" />
        </xctk:PropertyGrid.PropertyDefinitions>
    </xctk:PropertyGrid>
