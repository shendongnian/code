    // SampleViewModel.cs
    public ObservableCollection<string> Categories = new ObservableCollection<string>();
    // SampleView.xaml
    <Window.DataContext>
        <local:SampleViewModel/>
    </Window.DataContext>
    <ListView ItemSource="{Binding Categories}" />
