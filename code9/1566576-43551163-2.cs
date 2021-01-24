    using Prism.Mvvm;
    public class Person : BindableBase
    {
        private string _name;
        public string Name
        {
            get { return _name; }
            set { SetProperty(ref _name, value); }
        }
        private int _age;
        public int Age
        {
            get { return _age; }
            set { SetProperty(ref _age, value); }
        }
        private int _id;
        public int Id
        {
            get { return _id; }
            set { SetProperty(ref _id, value); }
        }
        private bool _isLoaded;
        public bool IsLoaded
        {
            get { return _isLoaded; }
            set { SetProperty(ref _isLoaded, value); }
        }
    }
