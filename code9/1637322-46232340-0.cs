    using Moq;
    public class FooEntity
    {
        //if Bar is a table, you should write like this:
    	public virtual BarEntity Bar {get;set;}
    	public int BarId {get;set;}
    
    	public void DoSomething()
    	{
    		var result = Bar.DoSomethingElse();
    
    		if (result)
    			DoThis();
    		else
    			DoThat();
    	}
    
    	private void DoThis() { }
    	private void DoThat() { }
    }
    
    var mock = new Mock<BarEntity>();
    //DoSomethingElse method should be virtual and BarEntity should not be sealed
    mock.Setup(x => x.DoSomethingElse()).Returns(true);//or false
    var target2test = new FooEntity { Bar = mock.Object };
    //action:
    target2test.DoSomething();//will result to DoThis calling
