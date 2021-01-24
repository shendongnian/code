        public static List<string> ConvertToStringList(object value)
        {
            List<string> list = value as List<string>;
            if (list != null)
                return list.Select(s => s.Trim()).ToList();
            list = new List<string>();
            string stringValue = value as string;
            if (stringValue != null)
            {
                list.Add(stringValue);
            }
            else
            {
                IEnumerable enumerableValue = value as IEnumerable;
                if (enumerableValue == null)
                {
                    list.Add(value.ToString());
                }
                else
                {
                    foreach (object item in enumerableValue)
                        list.Add(item.ToString());
                }
            }
            return list.Select(s => s.Trim()).ToList();
        }
