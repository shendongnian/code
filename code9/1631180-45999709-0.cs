        [ConfigurationProperty("test")]
        public string Test
        {
            get { return (string) base["test"]; }
            set { base["test"] = value; }
        }
        public string[] TestSplit
        {
            get { return Test.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries); }
        }
