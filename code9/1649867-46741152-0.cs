    using System;
    using Newtonsoft.Json;
    
    class Person {
    	public string Name { get; set; }
    
    	public int Age { get; set; }
    
    	public override string ToString() {
    		return string.Format("Name: {0} \nAge: {1}", Name, Age);
    	}
    }
    
    public class Program {
    	public static void Main() {
    		var json = @"{
    			'Name': 'BOB',
    			'Age': 55
    		}";
    		var person = JsonConvert.DeserializeObject<Person>(json);
    		Console.WriteLine(person);
    	}
    }
