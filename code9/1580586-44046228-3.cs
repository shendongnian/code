        public void todatagrid()
        {
            List<Person> persons = new List<Person>();
            string textfile = "test.txt";
            var textvalues = File.ReadAllLines(textfile);
            foreach (var item in textvalues)
            {
                persons.Add(new Person() { Value = item });
            }
            datagrid.ItemsSource = persons;    
        }
        class Person
        {
            public string Value { get; set; }   //Whatever this field is
        }
