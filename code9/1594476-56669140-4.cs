    using System.Threading.Tasks;
    using FakeItEasy;
    using Xunit;
    namespace MyNamespace
    {
    	public class MyClass
    	{
    		private readonly object _lock = new object();
    		private readonly IMyInterface _noConfig;
    		private bool _initCalled;
    		public MyClass(IMyInterface noConfig)
    		{
    			_noConfig = noConfig;
    		}
    		public void Initialize()
    		{
    			if (_initCalled)
    			{
    				return;
    			}
    			lock (_lock)
    			{
    				if (_initCalled)
    				{
    					return;
    				}
    				_noConfig.Init();
    				_initCalled = true;
    			}
    		}
    	}
    	public interface IMyInterface
    	{
    		void Init();
    	}
    	public class MyTests
    	{
    		private readonly IMyInterface _myInterface;
    		private readonly MyClass _myClass;
    		public MyTests()
    		{
    			_myInterface = A.Fake<IMyInterface>();
    			_myClass = new MyClass(_myInterface);
    		}
    		[Fact]
    		public async void Initialize_CallConcurrently_InitNoConfigOnlyCalledOnce()
    		{
				A.CallTo(() => _myInterface.Init()).Invokes(() => Thread.Sleep(TimeSpan.FromMilliseconds(5)));
    			Task[] tasks =
    			{
    				Task.Run(() => _myClass.Initialize()),
    				Task.Run(() => _myClass.Initialize())
    			};
    			await Task.WhenAll(tasks);
    			A.CallTo(() => _myInterface.Init()).MustHaveHappenedOnceExactly();
    		}
    		[Fact]
    		public void Initialize_CallConsecutively_InitNoConfigOnlyCalledOnce()
    		{
    			_myClass.Initialize();
    			_myClass.Initialize();
    			A.CallTo(() => _myInterface.Init()).MustHaveHappenedOnceExactly();
    		}
    	}
    }
