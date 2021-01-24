    class Foo<T>
    {
        // Dedicated object instance used for locking
        private Object m_MyLock = new Object();
        T Eject(bool? state)
        {
            lock (m_MyLock)//You typically use the same locking object everywhere within the class
            {
                //somecode
                return _objects[i];
            }
        }
        string SomeOtherMethod()//Some other method that needs to be threadsafe too
        {
            lock (m_MyLock)//You typically use the same locking object everywhere within the class
            {
                return _objects[i].ToString();
            }
        }
        public T TakeNew()
        {
            return Eject(null);
        }
        public T Reserve()
        {
            return Eject(true);
        }
    }
