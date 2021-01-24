     Dictionary<string,object> dic = new Dictionary<string, object>();
                foreach (Property p in item.Properties)
                {
                    dic[p.Name] = p.Value;
                }
