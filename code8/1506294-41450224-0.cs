        public List<Publisher> Publishers
        {
            get { return _Publishers; }
            set { _Publishers = value; }
        }
        private List<Publisher> _Publishers;
        private Dictionary<string, Publisher> _PublishersDictionary;
        public Dictionary<string, Publisher> PublisherDictionary
        {
            get
            {
                if(this._PublishersDictionary == null)
                {
                    this._PublishersDictionary = this.Publishers.ToDictionary(p => p.Name, p => p);
                }
                return this._PublishersDictionary;
            }
        }
