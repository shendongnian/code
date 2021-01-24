    using Microsoft.Toolkit.Uwp;
    public class Person
    {
        public string Name { get; set; }
    }
    public class PeopleSource : IIncrementalSource<Person>
    {
        private readonly List<Person> people;
        public async Task<IEnumerable<InfoOverView>> GetPagedItemsAsync(int pageIndex, int pageSize, CancellationToken cancellationToken = default(CancellationToken))
        {
            return AddItems();
        }
        public void AddItems()
        {
            people.Clear();
            //Code to add the additional items in the people List
            return people;
        }
    }
    //In Page.xaml.cs
    public Page()
    {
        this.InitializeComponent();
        var collection = new IncrementalLoadingCollection<PeopleSource, Person>();
        MasterDetailsViewPanel.ItemsSource = collection;
    }
