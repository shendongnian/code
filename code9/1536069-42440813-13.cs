    public interface IDocument : IComponent {
        string Name { get; set; }
    }
    public interface IMetadata : IComponent {
        string[] Tags { get; set; }
    }
