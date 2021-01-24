        private bool IsSelfDuplicate(object myObj)
        {
            PropertyInfo[] props = myObj.GetType().GetProperties();
            for (int i = 0; i < props.Length; i++)
            {
                if (props[i].GetValue(myObj) == null)
                    continue;
                Type iType = (Nullable.GetUnderlyingType(props[i].PropertyType) ?? props[i].PropertyType);
                object iValue = Convert.ChangeType(props[i].GetValue(myObj), iType);
                
                for (int j = i + 1; j < props.Length; j++)
                {
                    if (props[j].GetValue(myObj) == null)
                        continue;
                    Type jType = (Nullable.GetUnderlyingType(props[j].PropertyType) ?? props[j].PropertyType);
                    object jValue = Convert.ChangeType(props[j].GetValue(myObj), jType);
                    if (iType == jType && iValue.ToString() == jValue.ToString())
                        return true;
                }
            }
            return false;
        }
