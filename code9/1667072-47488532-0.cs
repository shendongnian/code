    public static byte[] StructToArray<T>(T obj)
    {
        var size = Marshal.SizeOf(obj);
        var mem = new MemoryStream(size);
        var fields = obj.GetType().GetFields();
        var little = BitConverter.IsLittleEndian;
        foreach(var field in fields)
        {
            var val = field.GetValue(obj);
            var type = val.GetType();
            if(type == typeof(int))
            {
                var raw = BitConverter.GetBytes((int)val);
                if (little) raw = raw.Reverse().ToArray();
                mem.Write(raw, 0, raw.Length);
            }
            else if(type == typeof(int[]))
            {
                var array = (int[])val;
                var length = BitConverter.GetBytes(array.Length);
                if (little) length = length.Reverse().ToArray();
                var raw = array.Select(x => BitConverter.GetBytes(x)).ToList();
                if (little) raw = raw.Select(x => x.Reverse().ToArray()).ToList();
                // Write the length...
                mem.Write(length, 0, length.Length);
                // ...and the items in "normal" order
                for (int i = 0; i < raw.Count; i++)
                    mem.Write(raw[i], 0, raw[i].Length);                    
            }
        }
        return mem.ToArray();
    }
