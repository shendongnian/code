    [TestClass] 
    public class UnitComp1 
    { 
        [TestMethod] 
        public void SalaryCalculationTest() 
        { 
            Payroll pr = new Payroll(); 
            Assert.IsTrue(da.IsValidGrossAmount(2000), "Invalid gross amount"); 
        } 
    } 
    
    //Cycle 1 - Test fails
    public class Payroll
    {
       public bool IsValidGrossAmount(int amount)
       {
         throw new NotImplementedException();
       }
    }
    
    //Cycle 2 - Test passes (done)
    public class Payroll
    {
       public bool IsValidGrossAmount(int amount)
       {
         return amount > 1000;
       }
    }
