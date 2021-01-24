     public List<string> GetChangedProperties(object A, object B)
        {
           if (A!= null && B != null)
            {
                var type = typeof(T);
                var ignoreList = new List<string>(ignore);
          var unequalProperties =
                    from pi in type.GetProperties(BindingFlags.Public | BindingFlags.Instance)
                    where !ignoreList.Contains(pi.Name) && pi.GetUnderlyingType().IsSimpleType() && pi.GetIndexParameters().Length == 0
                    let AValue = type.GetProperty(pi.Name).GetValue(A, null)
                    let BValue = type.GetProperty(pi.Name).GetValue(B, null)
                    where AValue != BValue && (AValue == null || !AValue.Equals(BValue))
                    select pi.Name;
         return unequalProperties.ToList();
             }
        }
