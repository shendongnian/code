    public class AutoDisposeList<T> : List<T>, IDisposable where T : IDisposable
    {
        public void Dispose()
        {
            foreach (var obj in this)
            {
                obj.Dispose();
            }
        }
    }
    using (var myList = new AutoDisposeList<Desert>())
    {
    
    }
