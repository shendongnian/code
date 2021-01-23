    public ObservableCollection<Result> Results { get; set; }
    
    public class Result 
    {
      public string Name { get; set; }
      public string Result{ get; set; }
    }
    <ListView Grid.Row="1" ItemsSource={Binding Path=Results}>...
