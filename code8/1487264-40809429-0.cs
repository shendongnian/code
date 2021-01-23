    class DictionaryListViewPseudoBinder : IEnumerable
    {
        private ListView ListView { get; }
        private Dictionary<string,string> Dictionary { get; set; }
        public DictionaryListViewPseudoBinder(ListView listView)
        {
            ListView = listView;
            Dictionary = new Dictionary<string, string>();
        }
        public string this[string key]
        {
            get
            {
                return Dictionary.ContainsKey(key) ? Dictionary[key] : "";
            }
            set
            {
                if (Dictionary.ContainsKey(key))
                {
                    Dictionary[key] = value;
                    RepopulateListView();
                }
                else
                {
                    MessageBox.Show("Dictionary does not contain key " + key + " aborting...");
                }
            }
        }
        public void Add(string key, string value)
        {
            if (!Dictionary.ContainsKey(key))
            {
                Dictionary.Add(key, value);
                RepopulateListView();
            }
            else
            {
                MessageBox.Show(string.Format("The Entry \"{0}\" already exists in {1}",key,ListView.Name));
            }
        }
        public void Remove(string key)
        {
            if (Dictionary.ContainsKey(key))
            {
                Dictionary.Remove(key);
            }
        }
        public bool ContainsKey(string key)
        {
            return Dictionary.ContainsKey(key);
        }
        public bool ContainsKVP(KeyValuePair<string, string> kvp)
        {
            if (!Dictionary.ContainsKey(kvp.Key))
            {
                return false;
            }
            else
            {
                return Dictionary[kvp.Key] == kvp.Value;
            }
        }
        private void RepopulateListView()
        {
            ListView.Items.Clear();
            foreach (KeyValuePair<string, string> kvp in Dictionary)
            {
                ListView.Items.Add(kvp.Key).SubItems.Add(kvp.Value);
            }
        }
        public IEnumerator GetEnumerator()
        {
            return Dictionary.GetEnumerator();
        }
    }
