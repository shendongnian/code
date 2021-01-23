    public abstract class MyAbstractBaseClass
    {
        protected virtual int MyFunctionalBaseClassMethod(int parameter1)
        {
            return (parameter1 * parameter1);
        }
    }
    public class MyChildClass : MyAbstractBaseClass
    {
        public int GetSquare(int parameter1) //(target method for unit test)
        {
            return MyFunctionalBaseClassMethod(parameter1); //(target method to mock using Fakes)
        }
    }
