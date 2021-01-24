        object _updateLock = new object();
        bool _isUpdating = false;
        bool IsUpdating
        {
            get { return _isUpdating; }
            set
            {
                lock (_updateLock)
                {
                    _isUpdating = value;
                }
            }
        }
        private void UpdateData()
        {
            if (!IsUpdating)
            {
                IsUpdating = true;
                updateCache(list1, cachelist);
                IsUpdating = false;
            }          
        }
 
        Dictionary<Tuple<int, string>, T> cache = new
              Dictionary<Tuple<int, string>, T>();
    
        public void updateCache()
        {
    
            foreach (var sr in searchResults)
            {
                var key = new Tuple<int, string>(sr.Number, sr.FileName);
                cache[key] = sr;
            }
        }
