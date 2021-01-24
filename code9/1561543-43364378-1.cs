    //SecA:
    public class SecA
      	{
		[FindsBy(How = How.Id, Using = "Id")]
		private IWebElement SecAField;
		//Add Getters, setters, methods, constructors, etc..
	}
	//SecB:
	public class SecB
	{
		[FindsBy(How = How.Id, Using = "Id")]
		private IWebElement SecBField;
		//Add Getters, setters, methods, constructors, etc..
	}
	//SecC:
	public class SecC
	{
		[FindsBy(How = How.Id, Using = "Id")]
		private IWebElement SecCField;
		//Add Getters, setters, methods, constructors, etc..
	}
	//Page 1:
	public class Page1
	{
		public SecA secA { get; set; }
		public SecB secB { get; set; }
		public SecC secC { get; set; }
		
		//Add Getters, setters, methods, constructors, etc..
		public Page1()
		{
			secA = new SecA();
			secB = new SecB();
			secC = new SecC();
		}
	}
