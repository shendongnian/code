    class Foo<T>
    {
        // Dedicated object instance used for locking
        private Object m_MyLock = new Object();
        T Eject(bool? state)
        {
            lock (m_MyLock)
            {
                //somecode
                return _objects[i];
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
