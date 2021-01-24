     public static string ConvertEnumsToJson<T>(Type e)
            {
    
                var ret = "{";
                var index = 0;
                foreach (var val in Enum.GetValues(e))
                {
                    if (index > 0)
                    {
                        ret += ",";
                    }
                    var name = Enum.GetName(e, val);
                    ret += name + ":" + ((T)val) ;
                    index++;
                }
                ret += "}";
                return ret;
    
            }
