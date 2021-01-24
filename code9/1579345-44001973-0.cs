    public interface IFirst{ void GetFirstThing(); }
    public interface ISecond { void GetSecondThing(); }
    public class MyClass:MonoBehaviour, IFirst, ISecond
    {
        public void GetFirstThing(){}
        public void GetSecondThing(){}
    }
    
    public class ConsumerForFirstOnly
    {
        private IFirst first = null;
        public ConsumerForFirstOnly(IFirst first)
        {
            this.first = first;
        }
    }
