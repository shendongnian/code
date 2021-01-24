    public class Person
    {
        public string Name { get; set; }
    }
    var oc = new ObservableCollection<Person>
    {
        new Person { Name = "Staff" },
        new Person { Name = "42" },
        ......
        ......
    };
    var acv = new AdvancedCollectionView(oc);
    int nul;
    acv.Filter = x => !int.TryParse(((Person)x).Name, out nul); 
    YourGridView.ItemsSource = acv;
