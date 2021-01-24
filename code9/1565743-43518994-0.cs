    namespace playground
    {
        public class Program
        {
            public static void Main()
            {
                var testcase1 = DummyStateType1.State1;
                var testcase2 = DummyStateType2.OtherState1;
    
                var handler1 = StateHandlerFactory<DummyStateType1>.Create();
                var handler2 = StateHandlerFactory<DummyStateType2>.Create();
    
                var result1 = handler1.handle(testcase1);
                var result2 = handler2.handle(testcase2);
    
                var alsoResult1 = tadaaaa(testcase1);
                var alsoResult2 = tadaaaa(testcase2);
            }
            static bool tadaaaa<T>(T state)
            {
                return StateHandlerFactory<T>.Create().handle(state);
            }
        }
        public interface IStateHandler<T>
        {
            bool handle(T state);
        }
        public enum DummyStateType1
        {
            State1,
            State2
        }
        public enum DummyStateType2
        {
            OtherState1,
            OtherState2
        }
        public static class StateHandlerFactory<T>
        {
            public static IStateHandler<T> Create()
            {
                //this could be replaced by IoC ... or a reflection based lookup ... you name it...
                var type = typeof(T);
                if (type == typeof(DummyStateType1))
                    return (IStateHandler<T>)new DummyStateType1StateHandler();
                if (type == typeof(DummyStateType2))
                    return (IStateHandler<T>)new DummyStateType2StateHandler();
                throw new NotImplementedException();
            }
        }
        public class DummyStateType1StateHandler : IStateHandler<DummyStateType1>
        {
            public bool handle(DummyStateType1 state)
            {
                switch (state)
                {
                    case DummyStateType1.State1:
                        return false;
                    case DummyStateType1.State2:
                        return true;
                    default:
                        throw new NotImplementedException();
                }
            }
        }
        public class DummyStateType2StateHandler : IStateHandler<DummyStateType2>
        {
            public bool handle(DummyStateType2 state)
            {
                switch (state)
                {
                    case DummyStateType2.OtherState1:
                        return true;
                    case DummyStateType2.OtherState2:
                        return false;
                    default:
                        throw new NotImplementedException();
                }
            }
        }
    }
