    public class MyWrapper: IDisposable
    {
        int _id;
        public MyWrapper(int id)
        {
            _id = id;
            Debug.WriteLine("Begin " + _id);
        }
        public void Dispose()
        {
            Debug.WriteLine("End " + _id);
        }
    }
