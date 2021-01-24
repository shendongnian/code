    [TestClass]
	public class ObservaleTests
	{
	    private Action _action = null;
	
	    [TestMethod]
	    public void ObservesMethodCall()
	    {
	        var eventCount = 0;
	        IObservable<Unit> observable =
	    	    Observable.FromEvent(a => _action += a, a => _action += a);
	        observable.Subscribe(u => eventCount++);
	
	        Assert.AreEqual(0, eventCount);
	        Foo();
	        Assert.AreEqual(1, eventCount);
	    }
	
	    private void Foo()
	    {
	        _action();
	    }
	}
