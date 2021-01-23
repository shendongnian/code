    public class WindowVM: DependencyObject
    {
    public ObservableCollection<Person> People
    {
        get { return (string)GetValue(PeepleProperty); }
        set { SetValue(PeopleProperty, value); }
    }
    // Using a DependencyProperty as the backing store for name.  This enables animation, styling, binding, etc...
    //ect
    }
