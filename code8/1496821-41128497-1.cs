        public Dictionary<DialogResult, string> ButtonNames { get; set; }
        public IndexedProperty<DialogResult, string> ButtonName
        {
            get
            {
                return new IndexedProperty<DialogResult, string>(
                    r =>
                    {
                        if (ButtonNames.ContainsKey(r)) return ButtonNames[r];
                        return r.ToString();
                    }, (r, val) => ButtonNames[r] = val);
            }
        }
