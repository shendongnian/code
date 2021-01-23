        private string _bar = "foobar";
        public string Bar
        {
            get { return _bar; }
            set { _bar = value ?? _bar;  }
        }
