            static string GetSimpleType(object obj)
            {
               if (obj.GetType() == typeof(int))
               {
                   return "int"; 
               }
                return obj.GetType().ToString();
            }
