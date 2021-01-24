    public interface IWritableRootInfo : IReadOnlyRootInfo
    {
        new string Name { get; set; }
        new string Description { get; set; }
        new ImageData Image { get; set; }
        List<ChildData> Children { get; set; }
    }
