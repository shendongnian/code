    class TestClass
    {
        private readonly IEventRecorder _eventRecorder;
    
        protected TestClass(IEventRecorder eventRecorder)
        {
            _eventRecorder = eventRecorder;
        }
    
        public TestClass()
        {
        }
    
        private bool _someFlag;
        private object _sharedObject = new object();
        private readonly object _syncObject = new object();
    
        public object Read()
        {
            //lock (_syncObject)
            {
    #if DEBUG
                _eventRecorder?.Record(nameof(Read));
    #endif
                _someFlag = false;
                return _sharedObject;
            }
        }
    
        public void Write(object obj)
        {
            //lock (_syncObject)
            {
    #if DEBUG
                _eventRecorder?.Record(nameof(Write));
    #endif
                _someFlag = true;
                _sharedObject = obj;
            }
        }
    
        public interface IEventRecorder
        {
            void Record(string eventName);
        }
    }
    
    public class TestClassTests
    {
        private class TestClassFake : TestClass
        {
            public TestClassFake(IEventRecorder record) : base(record)
            {
            }
        }
    
        private class EventRecorder : TestClass.IEventRecorder
        {
            private string _events = string.Empty;
    
            public void Record(string eventName) => _events += eventName;
    
            public string Events => _events;
    
            public void Reset() => _events = string.Empty;
        }
    
        [Fact]
        public void RaceConditionTest()
        {
            var correctObject = new object();
            var eventRecorder = new EventRecorder();
            var test = new TestClassFake(eventRecorder);
    
            for (int i = 0; i < 1000; i++)
            {
                test.Write(correctObject);
                var assertTask = Task.Run(() =>
                {
                    var actualObj = test.Read();
                    if (eventRecorder.Events.StartsWith("WriteRead"))
                        Assert.True(object.ReferenceEquals(correctObject, actualObj), $"Failed on {i} iteration");
                });
                var failTask = Task.Run(() => test.Write(new object()));
    
                Task.WaitAll(assertTask, failTask);
                eventRecorder.Reset();
            }
        }
    }
