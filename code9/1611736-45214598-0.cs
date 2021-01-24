    public class Program
    {
    	public interface IModel {}
    	
    	public class Model1 : IModel{}
    	public class Model2 : IModel {
    		public string Field03 {get;set;}
    	}
    	public static void Main()
    	{
    		Func<IModel, string> predicateField03 = s => s.GetType().GetProperty("Field03") != null && s.GetType().GetProperty("Field03").GetValue(s).ToString().ToLower().Contains("33") ? 
    			s.GetType().GetProperty("Field03").GetValue(s).ToString() : string.Empty;
    		
    		Console.WriteLine(predicateField03(new Model1()));
    		Console.WriteLine(predicateField03(new Model2(){Field03 = "333"}));
    		
    	}
    }
