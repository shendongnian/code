    public interface IViewModel
    {
        string PropertyName { get; set; }
    }
    
    public class StringViewModel : IViewModel
    {
        public string PropertyName { get; set; }
        public string Content { get; set; }
    }
    
    public class BooleanViewModel : IViewModel
    {
        public string PropertyName { get; set; }
        public bool IsChecked { get; set; }
    }
    
    public class MainViewModel
    {
        public ObservableCollection<IViewModel> ViewModels { get; set; }
    
        public MainViewModel()
        {
            ViewModels = new ObservableCollection<IViewModel>
            {
                new BooleanViewModel {PropertyName = "Bool", IsChecked = true },
                new StringViewModel {PropertyName = "String", Content = "My text"}
            };
    
        }
    }
    
    <Window x:Class="WpfApplication2.MainWindow"
            xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
            xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
            xmlns:d="http://schemas.microsoft.com/expression/blend/2008"
            xmlns:mc="http://schemas.openxmlformats.org/markup-compatibility/2006"
            xmlns:local="clr-namespace:WpfApplication2"
            mc:Ignorable="d"
            xmlns:viewModel="clr-namespace:WpfApplication2"
            Title="MainWindow">
        <Grid>
            <ListView ItemsSource="{Binding ViewModels}">
                <ListView.ItemTemplate>
                    <DataTemplate>
                        <StackPanel Orientation="Horizontal"
                                    Margin="8">
                            <TextBlock Text="{Binding PropertyName}" />
                            <ContentControl FontSize="14" Content="{Binding .}">
                                <ContentControl.Resources>
                                    <DataTemplate DataType="{x:Type viewModel:StringViewModel}">
                                        <TextBox Text="{Binding Content}" />
                                    </DataTemplate>
                                    <DataTemplate DataType="{x:Type viewModel:BooleanViewModel}">
                                        <CheckBox IsChecked="{Binding IsChecked}" />
                                    </DataTemplate>
                                </ContentControl.Resources>
                            </ContentControl>
                        </StackPanel>
                    </DataTemplate>
                </ListView.ItemTemplate>
            </ListView>
        </Grid>
    </Window>
