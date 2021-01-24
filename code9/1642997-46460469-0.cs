    public class Model
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public List<Model> Children { get; set; }
    }
    public class ViewModel
    {
        public ViewModel(Model m)
        {
            Name = m.Name;
            Age = m.Age;
            Children = new ObservableCollection<ViewModel>(m.Children.Select(md=>new ViewModel(md)));
        }
        public string Name { get; set; }
        public int Age { get; set; }
        public ObservableCollection<ViewModel> Children { get; set; }
        public Model GetModel()
        {
            return new Model()
            {
                Age = Age,
                Name = Name,
                Children = Children.Select(vm=>vm.GetModel()).ToList(),
            };
        }
    }
