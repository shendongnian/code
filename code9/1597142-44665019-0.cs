    internal class Program {
        public static void Main(string[] args) {
            List<String> list = new List<String>();
            Type t = list.GetType();
            string yourString = string.Format(
                                              "{0}.{1}.[[{2}, {3}]], {3}",
                                              t.Namespace,
                                              t.Name,
                                              t.GetGenericArguments()[0],
                                              t.Assembly.GetName().Name);
            Console.WriteLine(yourString);
            // This prints :
            //System.Collections.Generic.List`1[[System.String, mscorlib]], mscorlib
        }
    }
