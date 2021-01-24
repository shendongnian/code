        /// <summary>
        /// Current culture of this form
        /// </summary>
        [Browsable(false)]
        [Description("Current culture of this form")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public CultureInfo Culture
        {
            get { return this.culture; }
            set
            {
                if (this.culture != value)
                {
                    ResourceSet resourceSet = new ComponentResourceManager(GetType()).GetResourceSet(value, true, true);
                    IEnumerable<DictionaryEntry> entries = resourceSet
                        .Cast<DictionaryEntry>()
                        .Where(x => x.Key.ToString().Contains(".Text"))
                        .Select(x => { x.Key = x.Key.ToString().Replace(">", "").Split('.')[0]; return x; });
                    foreach (DictionaryEntry entry in entries)
                    {
                        if (!entry.Value.GetType().Equals(typeof(string))) return;
                        string Key = entry.Key.ToString(),
                               Value = (string) entry.Value;
                        try
                        {
                            Control c = Controls.Find(Key, true).SingleOrDefault();
                            c.Text = Value;
                        }
                        catch
                        {
                            Console.WriteLine("Control {0} is null in form {1}!", Key, GetType().Name);
                        }
                    }
                    this.culture = value;
                    this.OnCultureChanged();
                }
            }
        }
