    public abstract class Report
    {
    	public List<a> Coils { get; set; }
    }
    
    public class ProductionExitCoilReport : Report
    {
    
    }
    
    public class a
    {
    	public string SomeProperty { get; set; }
    }
    
    public class A : a
    {
    	public string SomeOtherProperty { get; set; }
    }
    
    public void SomeMethod()
    {
    	//to store the coil
    	ProductionExitCoilReport myReport = new ProductionExitCoilReport();
    	myReport.Coils.Add(new A());
    
    	//to retreive SomeOtherProperty from the first element in the list
    	string retrievedProperty = ((A)myReport.Coils[0]).SomeOtherProperty;
    }
