    public class TEST : INotifyPropertyChanged
    {
        public TEST()
        {
            SourceCollection = RandomWords();
        }
        public System.Collections.IEnumerable SourceCollection { get; private set; }
        public object RandomWords()
        {
            TABUEntities baza = new TABUEntities();
            var a = baza.HASLA.OrderBy(x => Guid.NewGuid()).Take(1).ToList();
            return a;
        }
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string name)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }
    }
----------
    <Window x:Class="Tabu.View.TEST"
        xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
        xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
        xmlns:d="http://schemas.microsoft.com/expression/blend/2008"
        xmlns:mc="http://schemas.openxmlformats.org/markup-compatibility/2006"
        xmlns:local="clr-namespace:Tabu.View"
        xmlns:vm="clr-namespace:Tabu.ViewModel"
        mc:Ignorable="d"
        Title="TEST" Height="600" Width="600">
        <Window.DataContext>
            <vm:TEST/>
        </Window.DataContext>
        <Grid>
            <DataGrid ItemsSource="{Binding SourceCollection}" />
        </Grid>
    </Window>
