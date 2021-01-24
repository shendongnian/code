    static unsafe byte[] Serialize(List<Vector> vectors)
    {
        var arr = new byte[3 * sizeof(float) * vectors.Count];
        fixed(byte* ptr = arr)
        {
            var typed = (float*)ptr;
            foreach(var vec in vectors)
            {
                *typed++ = vec.X;
                *typed++ = vec.Y;
                *typed++ = vec.Z;
            }
        }
        return arr;
    }
    static unsafe List<Vector> Deserialize(byte[] arr)
    {
        int count = arr.Length / (3 * sizeof(float));
        var vectors = new List<Vector>(count);
        fixed (byte* ptr = arr)
        {
            var typed = (float*)ptr;
            for(int i = 0; i < count; i++)
            {
                var x = *typed++;
                var y = *typed++;
                var z = *typed++;
                vectors.Add(new Vector(x, y, z));
            }            
        }
        return vectors;
    }
