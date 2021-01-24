    public class MyContextData<T>
    {
        public T PropertyValue { get; set; }
    }
    // initialize DataContext somewhere
    private void Window_Loaded(object sender, RoutedEventArgs e)
    {
        grid1.DataContext = new MyContextData<bool>() { PropertyValue = true };
        //grid1.DataContext = new MyContextData<string>() { PropertyValue = "ABC" };
    }
