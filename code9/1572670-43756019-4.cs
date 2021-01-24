    public class BaseViewPage<TModel> : WebViewPage<TModel>
    {
    	private MyCustomHelper _foo;
    	
    	public MyCustomHelper Foo
    	{
    		get
    		{
    			if (_foo == null)
    			{
    				_foo = new MyCustomHelper();
    			}
    			
    			return _foo;
    		}
    		set
    		{
    			_foo = value;
    		}
    	}
    }
    
    public class BaseViewPage : WebViewPage
    {
    	private MyCustomHelper _foo;
    	
    	public MyCustomHelper Foo
    	{
    		get
    		{
    			if (_foo == null)
    			{
    				_foo = new MyCustomHelper();
    			}
    			
    			return _foo;
    		}
    		set
    		{
    			_foo = value;
    		}
    	}
    }
