    public interface IParent 
    { 
        void Exec(); 
    }
    public class Child1 : IParent
    {
        void Exec() { /*code*/ }
    }
    public class Child2 : IParent
    {
        void Exec() { /*code*/ }
    }
    public class Child3 : IParent
    {
        void Exec() { /*code*/ }
    }
    public class MasterClass 
    {
        public void ExecutionMethod(IParent myObject)
        {
            //some code
            myObject.Exec();
            //some code
        }
    }
