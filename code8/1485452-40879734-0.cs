        [XmlIgnore]
        public List<KeyValuePair<string, object>> Items { get; set; }
        [XmlAnyElement]
        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never), DebuggerBrowsable(DebuggerBrowsableState.Never)]
        public XElement[] XmlItems
        {
            get
            {
                if (Items == null)
                    return null;
                return Items.Select(p => new XElement(p.Key, (p.Value ?? string.Empty).ToString())).ToArray();
            }
            set
            {
                if (value == null)
                    return;
                Items = Items ?? new List<KeyValuePair<string, object>>(value.Length);
                foreach (var e in value)
                {
                    Items.Add(new KeyValuePair<string, object>(e.Name.LocalName, e.Value));
                }
            }
        }
