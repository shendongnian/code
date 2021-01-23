    public abstract class Transform
    {
        public abstract Matrix ToMatrix();
    }
    public class Matrix : Transform
    {
        public int[,] Data { get; set; }
        public Matrix ToMatrix() { return this; }
    }
    public class OtherTypeOfTransform : Transform
    {
        public Matrix ToMatrix()
        {
            // Type-specific implementation
        }
    }
