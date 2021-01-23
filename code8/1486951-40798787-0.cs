      bool flg = list.All(m => CheckProperties(m));
      public static bool CheckProperties<T>(T source)
            {
                bool rtnFlg = true;
                Type t = typeof(T);
                var properties = t.GetProperties();
                foreach (var prop in properties)
                {
                    var value = prop.GetValue(source, null);
                    if (value == null)
                    {
                        return false;
                    }
                }
                return rtnFlg;
            }
