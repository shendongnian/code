    public interface ITask {
        IDocument Document { get; set; }
    }
    public interface IDocument {
        int Number { get; set; } // Example property.
    }
    public class Document : IDocument{
        public int Number { get; set; } // Example property.
    }
    public class Task : ITask {
        public IDocument Document { get; set; }
    }
