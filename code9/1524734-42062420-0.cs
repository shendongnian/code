    void Main()
    {
    	var test= new TestPrimaryObject(){ param1="param1", param2="param2", param3="Param3", param4="param4"};
    
    	Console.WriteLine(test);
    	
    	test.Formatter = new Param3And4();
    	
    	Console.WriteLine(test);
    	
    	test.Formatter = new Param1And2();
    	
    	Console.WriteLine(test);
    }
    
    public class TestPrimaryObject 
    {
        public TestPrimaryObject(){
    	  Formatter= new Param1And2(); // set default here
    	}
    	
        public string param1 { get; set; }
        public string param2 { get; set; }
    
        public string param3 { get; set; }
        public string param4 { get; set; }
    	
    	public  IStringOverride<TestPrimaryObject> Formatter {get;set;}
    	
    	public override string ToString(){
    	   return Formatter.Format(this);
    	}
    }
    
    public interface IStringOverride<T>{
       string Format(T arg);
    }
    
    public class Param1And2 : IStringOverride<TestPrimaryObject>{
    
         
    	public string Format(TestPrimaryObject arg){
    	  return string.Format("http://example.com?var1={0}&var2={1}", arg.param1, arg.param2); 
    	}
    }
    
    public class Param3And4 : IStringOverride<TestPrimaryObject>{
    
    	public string Format(TestPrimaryObject arg){
    	 return string.Format("http://example.com?var1={0}&var2={1}", arg.param3, arg.param4); 
    	}
    }
