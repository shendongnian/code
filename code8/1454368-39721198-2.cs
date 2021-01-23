      public List<object> Childrens
        {
            get 
            {
                _childrens = new List<object>();
                foreach (var subNode in SubNodes)
                {
                    _childrens.Add(subNode);
                }
                foreach (var userDataEntry in Entries)
                {
                    _childrens.Add(userDataEntry);
                }
                return _childrens;
            }
            private set { _childrens = value; }
        }
