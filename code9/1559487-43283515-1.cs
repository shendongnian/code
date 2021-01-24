    public class MyObject<T> where T : ObjectBase, new()
    {
        //public void Put<T>(MyObject<T> obj)//doesn't work
        public void Put(MyObject<T> obj)//works
        {
            // code
        }
    }
