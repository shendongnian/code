	namespace Foo
	{
	  [TestFixture]
	  public class YourServiceTests
	  {
		private IYourService _service;
	  
		[OneTimeSetUp]
		public void Init()
		{ 
		  /* Do whatever is necessary to initialize the service */ 
		  _service = CreateNewInstance();
		}
		[OneTimeTearDown]
		public void Cleanup()
		{ 
		  /* optionally provide a teardown method to gracefully shutdown the service */ 
		}
		[Test]
		public void TestA()
		{ 
		  var expected = "bar";
		  var actual = _service.MethodA();
		  Assert.That(actual, Is.EqualTo(expected));
		}
		[Test]
		public void TestB()
		{ 
		  // ...
		}
	  }
	}
