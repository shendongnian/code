    [TestClass]
    public class MyTestClass
    {
        public class MyTestInputType{public string Key; public Func<string> F; }
        public IEnumerable TestInputs 
	    {
    		get
	    	{
		    	return new MyTestInputType[] 
			    { 
    				new MyTestInputType(){ Key = "1", F = () => "" }, 
	    			new MyTestInputType() { Key = "2", F = () => "2" } 
		    	};
    		}
	    }
        [AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
        public class DataTestMethodWithTestInputsFromThisTestProjectAttribute : DataTestMethodWithTestInputsFromClassPropertyAttribute
        {
            public DataTestMethodWithTestInputsFromThisTestProjectAttribute() 
                : base(typeof(MyTestClass), nameof(MyTestClass.TestInputs)) { }
            public override string GetDisplayNameForTestItem(object testItem)
            {
                var asTestInput = testItem as MyTestInputType;
                if (asTestInput == null)
                    return null;
                return asTestInput.Key;
            }
        }
        [DataTestMethodWithTestInputsFromThisTestProject]
        public void TestMethod1(MyTestInputType testInput)
        {
             Assert.IsTrue(testInput.Key == testInput.F());
        }
        [DataTestMethodWithTestInputsFromThisTestProject]
        public void TestMethod2(MyTestInputType testInput)
        {
            Assert.IsTrue(string.IsNullOrEmpty(testInput.F()));
        }
    }
