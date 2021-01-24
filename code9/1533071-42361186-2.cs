        public IEnumerable<IEnumerable<MyString>> ListOfStringLists { get; set; } = new[] { new[] { new MyString("a"), new MyString("b") { IsSelected = true } }, new[] { new MyString("c"), new MyString("d") } };
        public MainWindow()
        {
            this.InitializeComponent(); 
            DoSomethingButton.Click += (sender, e) =>
            {
                foreach (var i in ListOfStringLists)
                    foreach (var j in i)
                    {
                        if (j.IsSelected)
                        {
                            // ....
                        }
                    }
            };
        }
