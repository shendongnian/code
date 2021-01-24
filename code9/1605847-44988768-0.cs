    public class Rectangle : Shape
    {
        private int num = 10;
        ...
        ovrride public string ToString()
        {
            return $"Rectangle num = {num}";
        }
    }
...
    Console.WriteLine(shape); // Uses ToString()
