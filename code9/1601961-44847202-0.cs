        public ObservableCollection<Person> Peoples
        {
            get;
        }
        public MyConstructor()
        {
            Peoples = new ObservableCollection<Person>();
        }
        
        public void RefreshPeopleCollection(IEnumerable<Person> persons)
        {
            Peoples.Clear();
            foreach(var person in persons)
            {
                Peoples.Add(person);
            }
        }
