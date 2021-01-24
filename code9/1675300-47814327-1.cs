        private bool IsDuplicate(object obj1, object obj2)
        {
            PropertyInfo[] props = obj1.GetType().GetProperties();
            for (int i = 0; i < props.Length; i++)
            {
                if (props[i].GetValue(obj1) == null)
                    continue;
                Type iType = (Nullable.GetUnderlyingType(props[i].PropertyType) ?? props[i].PropertyType);
                object iValue = Convert.ChangeType(props[i].GetValue(obj1), iType);
                for (int j = 0; j < props.Length; j++)
                {
                    if (props[j].GetValue(obj2) == null)
                        continue;
                    Type jType = (Nullable.GetUnderlyingType(props[j].PropertyType) ?? props[j].PropertyType);
                    object jValue = Convert.ChangeType(props[j].GetValue(obj2), jType);
                    if (iType == jType && iValue.ToString() == jValue.ToString())
                        return true;
                }
            }
            return false;
        }
