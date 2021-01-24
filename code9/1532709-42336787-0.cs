      public static List<List<string>> Split(this List<string> list, string splitter)
            {
                var _list = new List<List<string>>();
                var count = list.Count(x => x == splitter);
                list.ForEach(item =>
                {
                    if(item == splitter)
                    {
                        _list.Add(new List<string>());
                    }
                    _list.LastOrDefault()?.Add(item);
                });
                return _list.ToList();
            }
