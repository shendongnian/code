    public class cAssociativeArray
    {
        private dynamic _data = new ExpandoObject();
        public object this[params string[] keys]
        {
            get { return getValue(keys); }
            set { setValue(value, keys); }
        }
        private void setValue(object _value, params string[] keys)
        {
            dynamic lastObject = _data;
            string lKey = keys.Last();
            foreach (var key in keys.Take(keys.Count() - 1))
            {
                var dic = lastObject as IDictionary<string, Object>;
                if (!dic.ContainsKey(key))
                {
                    dic.Add(key, new ExpandoObject());
                }
                lastObject = dic[key];
            }
            if ((lastObject as IDictionary<string, object>) != null)
            {
                if (!(lastObject as IDictionary<string, object>).ContainsKey(keys.Last())) // add value
                {
                    (lastObject as IDictionary<string, object>).Add(lKey, _value);
                }
                else //change value
                {
                    if (keys.Count() > 1)
                    {
                        (lastObject as IDictionary<string, object>)[lKey] = _value;
                    }
                }
            }
        }
        private string getValue(params string[] keys)
        {
            dynamic lastObject = _data;
            string lKey = keys.Last();
            foreach (var key in keys.Take(keys.Count() - 1))
            {
                var dic = lastObject as IDictionary<string, Object>;
                if ((dic != null) && (dic.ContainsKey(key)))
                {
                    lastObject = dic[key] as ExpandoObject;
                }
                else
                {
                    return null;
                }
            }
            if (((lastObject as IDictionary<string, object>) != null) && ((lastObject as IDictionary<string, object>).ContainsKey(lKey))
                                                                      && (!((lastObject as IDictionary<string, object>)[lKey] is ExpandoObject)))
            {
                return (lastObject as IDictionary<string, object>)[lKey].ToString();
            }
            else
            {
                return null;
            }
        }
        public string[] getKeys(params string[] keys)
        {
            dynamic lastObject = _data;
            foreach (var key in keys.Take(keys.Count()))
            {
                var dic = lastObject as IDictionary<string, Object>;
                if ((dic != null) && (dic.ContainsKey(key)))
                {
                    lastObject = dic[key] as ExpandoObject;
                }
                else
                {
                    return null;
                }
            }
            if ((lastObject as IDictionary<string, object>) != null)
            {
                return (lastObject as IDictionary<string, object>).Keys.ToArray();
            }
            else
            {
                return null;
            }
        }
        public int countKeys(params string[] keys)
        {
            dynamic lastObject = _data;
            foreach (var key in keys.Take(keys.Count()))
            {
                var dic = lastObject as IDictionary<string, Object>;
                if ((dic != null) && (dic.ContainsKey(key)))
                {
                    lastObject = dic[key] as ExpandoObject;
                }
                else
                {
                    return -1;
                }
            }
            if ((lastObject as IDictionary<string, object>) != null)
            {
                return (lastObject as IDictionary<string, object>).Count();
            }
            else
            {
                return -1;
            }
        }
        public void printDebug(params string[] keys)
        {
            Debug.WriteLine("");
            printDebugSub("", keys);
            Debug.WriteLine("");
        }
        private void printDebugSub(string spaceStr, params string[] keys)
        {
            dynamic lastObject = _data;
            foreach (var key in keys.Take(keys.Count()))
            {
                var dic = lastObject as IDictionary<string, Object>;
                if ((dic != null) && (dic.ContainsKey(key)))
                {
                    lastObject = dic[key] as ExpandoObject;
                }
            }
            if ((lastObject as IDictionary<string, object>) != null)
            {
                foreach (string keyStr in (lastObject as IDictionary<string, object>).Keys.ToArray())
                {
                    string valueStr = "";
                    if (!((lastObject as IDictionary<string, object>)[keyStr] is ExpandoObject))
                    {
                        valueStr = " = " + (lastObject as IDictionary<string, object>)[keyStr].ToString();
                    }
                    Debug.WriteLine(spaceStr + keyStr + valueStr);
                    List<string> lst = keys.ToList();
                    lst.Add(keyStr);
                    printDebugSub(spaceStr.Trim() + "---- ", lst.ToArray());
                }
            }
            else
            {
                return;
            }
        }
    }
