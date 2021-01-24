    public interface IFace
    {
        // Include anything that doesn't need the type parameters here
    }
    public interface IFace<T1, T2> : IFace
    {
        // Include anything that needs the type parameters here
    }
