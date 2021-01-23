     private List<ObservableCollection<TestEntity>> _source = new List<ObservableCollection<TestEntity>>();
        public List<ObservableCollection<TestEntity>> SourceList
        {
            get { return _source; }
            set { _source = value; }
        }
        public DataContext()
        {
            this.SourceList.Add(new ObservableCollection<TestEntity> { new TestEntity { Age = 21 , Name = "Chris" , Surname = "James"}});
            this.SourceList.Add(new ObservableCollection<TestEntity> { new TestEntity { Age = 23, Name = "Jin", Surname = "Evelin" } });
            this.SourceList.Add(new ObservableCollection<TestEntity> { new TestEntity { Age = 33, Name = "Ryan", Surname = "Thrusty" } });
            this.SourceList.Add(new ObservableCollection<TestEntity> { new TestEntity { Age = 34, Name = "Martin", Surname = "Riggs" } });
        }
