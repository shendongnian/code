    using System.Linq;
    public class MyClass
    {
        public void MyMethod()
        {
            int[] numbers = { 1, 3, 5, 7, 9 };
            int threshold = 6;
            var query = from value in numbers where value >= threshold select value;
            threshold = 3;
            numbers = null;
            var result = query.ToList();
        }
    }
