public class Animal
    {
        public string Type { get; set; }
        public string Name { get; set; }
    }
    List<Animal> _animals = new List<Animal>();
    public MainWindow()
        {
            InitializeComponent();
            _animals.Add(new Animal { Type = "cat", Name = "Snowy" });
            _animals.Add(new Animal { Type = "cat", Name = "Toto" });
            _animals.Add(new Animal { Type = "dog", Name = "Oscar" });
            dataGrid1.ItemsSource = _animals;
        }
        List<Animal> filterModeLisst = new List<Animal>();
        private void searchBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            filterModeLisst.Clear();
            if (searchBox.Text.Equals(""))
            {
                filterModeLisst.AddRange(_animals);
            } else
            {
                foreach (Animal anim in _animals)
                {
                    if (anim.Name.Contains(searchBox.Text))
                    {
                        filterModeLisst.Add(anim);
                    }
                }
            }
            dataGrid1.ItemsSource = filterModeLisst.ToList();
        }
