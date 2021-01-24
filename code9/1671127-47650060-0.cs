    public static class StructSerializer
    {
        public static byte[] Serialize<T>(T data) where T : struct
        {
            List<byte> result = new List<byte>();
            IEnumerable<FieldInfo> orderedFields = data.GetType().GetFields().OrderBy(field => field.MetadataToken);
            foreach (FieldInfo fieldInfo in orderedFields)
            {
                object value = fieldInfo.GetValue(data);
                if(value is ushort us)
                    result.AddRange(BitConverter.GetBytes(us));
                else if (value is uint ui)
                    result.AddRange(BitConverter.GetBytes(ui));
            }
            return result.ToArray();
        }
    }
