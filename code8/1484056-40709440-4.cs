    public abstract class Transform { /* ... */ }
    public class Matrix : Transform
    {
        public int[,] Data { get; set; }
    }
    public class OtherTypeOfTransform : Transform
    {
        /* ... */
    }
