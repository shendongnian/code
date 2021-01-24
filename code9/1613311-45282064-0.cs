    public interface IReadOnlyRootInfo
    {
        string Name { get; }
        string Description { get; }
        ImageData Image { get; }
        List<ChildData> Children { get; }
    }
