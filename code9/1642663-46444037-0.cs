    public abstract class Detector
    {
        public void EventXHasHappened()
        {
            React();
        }
        protected abstract void React();
    }
    public class Derived : Detector
    {
        protected override void React()
        {
            //TODO - your code
        }
    }
