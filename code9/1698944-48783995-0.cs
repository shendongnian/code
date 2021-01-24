        static object DifferenceOfObjects(object objectNew, object objectOld)
        {
            dynamic expando = new ExpandoObject();
            var expandoDictionary = expando as IDictionary<String, object>;
            if (objectNew.GetType() != objectOld.GetType())
            {
                return expando;
            }
            var oType = objectOld.GetType();
            foreach (var oProperty in oType.GetProperties())
            {
                var oOldValue = oProperty.GetValue(objectOld, null);
                var oNewValue = oProperty.GetValue(objectNew, null);
                if (Equals(oOldValue, oNewValue))
                {
                    continue;
                }
                if (oNewValue is IEnumerable && oOldValue is IEnumerable)
                {
                    var enumerableNew = (oNewValue as IEnumerable).Cast<object>();
                    var enumerableOld = (oOldValue as IEnumerable).Cast<object>();
                    if (enumerableOld.SequenceEqual(enumerableNew))
                    {
                        continue;
                    }
                }
                expandoDictionary[oProperty.Name] = new { OldValue = oOldValue, NewValue = oNewValue };
            }
            return expando;
        }
