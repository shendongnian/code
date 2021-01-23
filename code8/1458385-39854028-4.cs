    public class MyClassWithEvent
    {
        public event EventHandler MyEvent;
        public int Field;
    }
    public class MyMainClass
    {
        private MyClassWithEvent myClass;
        private object mylock;
    
        public void Start()
        {
            myClass.MyEvent += new EventHandler(doSomething);
        }
        public void Stop()
        {
            myClass.MyEvent -= new EventHandler(doSomething);
            lock (mylock) //If somebody else already took the lock, we will wait here
            {
                myClass = null;
            } //We release the lock, so others can access it
        }
        private void doSomething()
        {
            lock(mylock)
            {
                if myClass != null
                {
                    myClass.Field = 42;
                }
            }
        }
    }
