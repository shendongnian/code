    public class RootData : IWritableRootInfo, IReadOnlyRootInfo
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public ImageData Image { get; set; }
        public List<ChildData> Children { get; set; }
    }
