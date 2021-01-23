    using System;
    namespace Demo
    {
        class MyType
        {
            public MyType ChangeBehavior()
            {
                Console.WriteLine("ChangeBehavior()");
                return this;
            }
            public void ChangeSize()
            {
                Console.WriteLine("ChangeSize()");
            }
        }
        class Program
        {
            static void Main()
            {
                var x = new MyType();
                test(true)(x);       // Calls ChangeBehavior()
                Console.WriteLine();
                test(false)(x);      // Calls ChangeBehavior() and then ChangeSize()
            }
            static Action<MyType> test(bool myBooleanCondition)
            {
                Action<MyType> myLambda = x => x.ChangeBehavior();
                if (!myBooleanCondition)
                    myLambda += x => x.ChangeSize();
                return myLambda;
            }
        }
    }
    
