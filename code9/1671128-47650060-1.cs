    public static class StructSerializer
    {
        public static byte[] Serialize<T>(T data) where T : struct
        {
            List<byte> result = new List<byte>();
            Type type = data.GetType();
            IEnumerable<FieldInfo> orderedFields = type.GetFields().OrderBy(f => Marshal.OffsetOf(type, f.Name).ToInt32());
            foreach (FieldInfo fieldInfo in orderedFields)
            {
                object value = fieldInfo.GetValue(data);
                MethodInfo conversion = typeof(BitConverter).GetMethod(nameof(BitConverter.GetBytes), new[]{fieldInfo.FieldType});
                if (conversion == null) continue;
                byte[] converted = (byte[])conversion.Invoke(null, new []{value});
                result.AddRange(converted);
            }
            return result.ToArray();
        }
    }
