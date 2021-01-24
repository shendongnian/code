    internal class XMemory<T>
    {
        private List<List<T>> EntityContents { get; set; } = new List<List<T>>();
    
        internal List<T> Read<T>()
        {
            var entityContent = EntityContents.FirstOrDefault();
    
            return entityContent;
        }
    }
