    public class Something
    {
        readonly IFrobber _frobber;
    	public Something(IFrobber frobber)
    	{
    	    _frobber=frobber;
    	}
    	
    	public void LetsFrobSomething(Thing theThing)
    	{
    	    _frobber.Frob(theThing)
    	}
    }
