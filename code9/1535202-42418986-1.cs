       public static class A
       {
   
        public static string Dump<T>(this T o)
        {
    
            var sb = new StringBuilder();
            using (TextWriter writer = LINQPad.Util.CreateXhtmlWriter(true))
            {
                writer.Write(o);
                sb.Append(writer);
            }
            return sb.ToString();
    
        }
    }
