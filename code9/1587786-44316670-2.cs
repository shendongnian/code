                var _nameValueLst = (from data in owner.GetType().GetProperties() select new { name = data.Name, value = data.GetValue(owner, null) }).ToList();
                NameValueCollection _myCollection = new NameValueCollection();
    
                foreach (var item in _nameValueLst)
                {
                    _myCollection.Add(item.name, item.value.ToString());
                }
    
                string _request = ToQueryString(_myCollection);
