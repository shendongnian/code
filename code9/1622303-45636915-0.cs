    public class Foo
    {
        private Object obj;
        public int Count
        {
            get
            {
                lock (obj)
                {
                    //this section is thread safe
                }
            }
            set
            {
                lock (obj)
                {
                    //this section is thread safe
                }
            }
        }
    }
