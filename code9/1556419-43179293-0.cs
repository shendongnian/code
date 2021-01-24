    public class DataContextWrapper : IDisposable {
        public DataContextWrapper() {
            DataContext = new DataContext();
        }
        internal DataContext DataContext { get; private set; }
        public void Dispose() {
            DataContext.Dispose();
        }
    }
