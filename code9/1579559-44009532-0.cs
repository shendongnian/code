    public class Program
    {
        public static void Main()
        {
            var array = new[] { "Hello" };
            array = array.Insert("World");
        }
    }
    public static class DummyExtension
    {
        public static T Insert<T>(this IList<T> list, T insertValue)
        {
            list.Add(insertValue);
            return insertValue;
        }
        public static T[] Insert<T>(this T[] list, T insertValue)
        {
            
            var destArray = new T[list.Length + 1];
            Array.Copy(list, destArray, list.Length);
            destArray[destArray.Length - 1] = insertValue;
            
            return destArray;
        }
    }
