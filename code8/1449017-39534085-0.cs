    private static StringBuilder GetObjectData(MyObject obj)
    {
        StringBuilder sb = new StringBuilder();
        obj.ToStringBuilder(ref sb);
        return sb;
    }
    class MyObject
    {
        MySubObject Object1;
        MySubObject Object2;
        public void ToStringBuilder(ref StringBuilder sb)
        {
            if (Object1 != null)
            {
                sb.AppendLine(Object1.ToStringBuilder(ref sb));
            }
            if (Object2 != null)
            {
                sb.AppendLine(Object2.ToStringBuilder(ref sb));
            }
        }
    }
    class MySubObject
    {
        object Field1;
        object Field2;
        
        public void ToStringBuilder(ref StringBuilder sb)
        {
            if (Field1 != null)
            {
                sb.AppendLine(Field1.ToString());
            }
            if (Field2 != null)
            {
                sb.AppendLine(Field2.ToString());
            }
        }
    }
