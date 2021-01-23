    public class ViewModel
    {
        public ViewModel()
        {
            this.testClassCollection = new ObservableCollection<TestClass>()
            {
                new TestClass() {ID = 1, Name = "Name1" },
                new TestClass() {ID = 2, Name = "Name2" },
                new TestClass() {ID = 3, Name = "Name3" }
            };
        }
        private ICollection<TestClass> testClassCollection;
        public ICollection<TestClass> TestClassCollection
        {
            get { return this.testClassCollection; }
            set { if (this.testClassCollection != value) { this.testClassCollection = value; } }
        }
        public class TestClass
        {
            public int ID { get; set; }
            public string Name { get; set; }
        }
    }
