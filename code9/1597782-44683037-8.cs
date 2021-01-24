    public interface Z
    {
        void F();
    }
    public class Generic<T> where T : Y, Z, new()
