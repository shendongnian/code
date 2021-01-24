    public class Data {
      public string Primary { get; set; }
      public string Secondary { get; set; }
    }
    
    // in your page's OnAppearing
    listView.ItemsSource = new List<Data>() { // initialize your list // };
    
    // XAML
    <ListView x:Name="listView">
        <ListView.ItemTemplate>
            <DataTemplate>
                <TextCell Text="{Binding Primary}" DetailText="{Binding Secondary}">
            <DataTemplate>
        </ListView.ItemTemplate>
    </ListView>
