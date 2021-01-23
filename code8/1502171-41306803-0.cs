    public static Dictionary<int, int> Foo(bool os, bool rad, bool aci, bool outr, string distrito = null)
    {
        var obj = new { os, rad, aci, outr};
        foreach (PropertyInfo pInfo in obj.GetType().GetProperties())
        {
            var value = (bool)pInfo.GetValue(obj);
            if (value)
            {
                //Do whatever you want here.                    
                Console.WriteLine("{0}: {1}", pInfo.Name, value);
            }
        }
    }
