    class A<T> where T : A<T>
    {
    	protected List<T> MakeList()
    	{
    		return new List<T>
        }
    }
    
    class B : A<B>
    {
    	protected void MyFunction()
    	{
    		List<B> x = MakeList();
    	}
    }
    
    class C : A<C>
    {
    	protected void MyFunction()
    	{
    		List<C> x = MakeList();
    	}
    }
