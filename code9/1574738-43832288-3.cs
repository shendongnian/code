    // The interfaces
    public interface ITask<TDocument> where TDocument : IDocument, new() {
         TDocument Document { get; set; }
    }
    public interface IDocument {
        int Number { get; set; } // Example property
    }
    //The classes
    public class Document : IDocument{
        public int Number { get; set; } // Example property
    }
    public class Task : ITask<Document> {
        public Document Document { get; set; }
    }
    // See if it works
    public class Test {
        private Task myTask = new Task();
        public void TestMethod() {
            myTask.Document.Number = 1;
        }
    }
