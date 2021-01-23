    using System.Text;
    public class MyClass {
        public static void Main(string[] args) {
            string input="AbCdEf";
    		StringBuilder s1 = new StringBuilder();
    		
    		foreach(char c in input){ 
    			if(char.IsLower(c)){ 
    				s1.Append(char.ToUpper(c));
    			}else{
    				s1.Append(char.ToLower(c));
    			}
    			
    
    		}
      
        System.Console.WriteLine(s1.ToString());
    
    	}
    }
