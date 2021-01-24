    public class Foo
    {
    	private string _bar;
    	private string _barrier;
    	
        public Foo(string bar = "hello", string barrier = "world"){
    		_bar = bar;
    	    _barrier = barrier;
        }
    	
    	public void show()
    	{
    		Console.WriteLine("_bar = " + _bar + " , _barrier = " + _barrier);
    	}
    }
