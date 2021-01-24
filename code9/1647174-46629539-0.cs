    public class MyList<T> : List<T> where T : new()
    {
        public MyList(T o, int times)
        {
            for (int i = 0; i < times; i++)
            {
                this.Add(o);
            }
        }
    }
