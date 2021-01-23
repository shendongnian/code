        public class TestClass
        {
        	public string S1 { get; set; }
        	public string S2 { get; set; }
        }
        
        [TestMethod]
        public void MyTest()
        {
        	//            Material Control     August
        	//Development         September
        	//Planning            August
        	//HR                  September
        
        	var list = new List<TestClass>
        	{
        		new TestClass {S1 = "Material Control", S2 = "August"},
        		new TestClass {S1 = "Development", S2 = "September"},
        		new TestClass {S1 = "Planning", S2 = "August"},
        		new TestClass {S1 = "HR", S2 = "September"}
        	};
        
        	var listGroupByMonth = list.GroupBy(l => l.S2);
        	foreach (var lstByMonth in listGroupByMonth)
        	{
        		var key = lstByMonth.Key;
        		var finalValue = string.Join(", ", lstByMonth.ToList().Select(lbm => lbm.S1));
    	}
    }
