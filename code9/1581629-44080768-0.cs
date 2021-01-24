    private static void CopyFlavorToGenericList<T1, T2>(List<T1> fromList, List<T2> toList) where T2 : new()
    {
        var map = from p1 in typeof(T1).GetProperties()
                  join p2 in typeof(T2).GetProperties()
                      on p1.Name equals p2.Name
                  select new { From = p1, To = p2 };
        foreach (var t in fromList)
        {
            T2 toObject = new T2();
            foreach (var copyItem in map)
            {
                if (copyItem.To.CanWrite)
                {
                    copyItem.To.SetValue(toObject, copyItem.From.GetValue(t));
                }
            }
            toList.Add(toObject);
        }
    }
