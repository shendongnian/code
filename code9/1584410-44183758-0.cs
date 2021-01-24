     public abstract class BaseClass : IDisposable
     {
            public int Value;
            void IDisposable.Dispose() => DoSomething();
            public void DoSomething() => Value = 1;
     }
    
     public class SubClass : BaseClass, IDisposable
     {
            void IDisposable.Dispose()
            {
                if (Condition())
                    DoSomething();
                else
                    DoSomethingElse();
            }
    
            void DoSomethingElse() => Value = 2;
    
            private bool Condition()
            {
                return true;
            }
    
    
     }
