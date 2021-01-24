    var data = new Dictionary<string, Dictionary<string, object>>();
    
                foreach (var j in GetTopData())
                {
                    foreach (var p in BottomData())
                    {
                        if(data.ContainsKey(j.ToString()))
                        {
                            var mydict = data[j.ToString()];
                            if (!mydict.ContainsKey(p.Name))
                                data[j].Add(p.Name, p.Value);
                        }
                        else
                        {
                            data.Add(j, new Dictionary<string, object> { { p.Name, p.Value } });
                        }
                    }
                }
