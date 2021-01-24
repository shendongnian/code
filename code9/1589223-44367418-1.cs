            var data = new Dictionary<string, Dictionary<string, List<object>>>();
            foreach (var j in GetTopData())
            {
                foreach (var p in BottomData())
                {
                    Dictionary<string, List<object>> values;
                    var existed = data.TryGetValue(j, out values);
                    if (!existed)
                        values = new Dictionary<string, List<object>>();
                    List<Object> list;
                    var existed2 = values.TryGetValue(p.Name, out list);
                    if (!existed2)
                        list = new List<object>();
                    list.Add(p.Value);
                    if (!existed)
                        data.Add(j, values);
                    if (!existed2)
                        values.Add(p.Name, list);
                }
            }
