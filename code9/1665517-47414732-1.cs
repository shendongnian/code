    public class SomeObject
    {
        public WeakEvent WeakMyEvent = new WeakEvent();
    }
    public class MyClass
    {
        public SomeObject TheObject { get; }
        public MyClass()
        {
            TheObject = new SomeObject();
            TheObject.WeakMyEvent.Register(this, t => t.MyEventHandler());
        }
        private void MyEventHandler()
        {
            // some code
        }
    }
