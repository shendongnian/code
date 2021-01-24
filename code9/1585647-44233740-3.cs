    class Program
    {
        static void Main(string[] args)
        {
            string[] s = new string[] { "hi", "hello", "what's up" };
            string[] newS = s.ArrayTo<string>(x => x.Remove(0, 1) );
            foreach (string str in newS)
                Console.WriteLine(str);
        }
    }
    static class Ext
    {
        public static T[] ArrayTo<T>(this T[] t, Func<T,T> a)
        {
            List<T> ret = new List<T>();
            foreach (T tOb in t)
            {
                ret.Add(
                    a(tOb));
            }
            return ret.ToArray();
        }
    }
