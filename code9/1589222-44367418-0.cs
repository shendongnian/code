            var data = new Dictionary<string, Dictionary<string, object>>();
            foreach (var j in GetTopData())
            {
                foreach (var p in BottomData())
                {
                    Dictionary<string, object> values;
                    var existed = data.TryGetValue(j, out values);
                    if (!existed)
                        values = new Dictionary<string, object>();
                    values.Add(p.Name, p.Value);
                    if (!existed)
                        data.Add(j, values);
                }
            }
