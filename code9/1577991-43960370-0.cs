    using System;
    using Newtonsoft.Json;    					
    public class Program
    {
    	public static void Main()
    	{
    		var obj = new Rootobject() {
    			resourceType = "Observation",
    			code = new Code() {
    				coding = new Coding[] {
    					new Coding() {
    						system = "http://",
    						code = "3637",
    						display = "Gene",
    					},
    				},
    				text = "Dip",
    			},
    			subject = new Subject() {
    				reference = "Pat",
    				display = "",
    			},
    			valueString = "*1/*1",
    			component = new Component[] {
    				new Component() {
    					code = new Code2(){
    						coding = new Coding[] {
    							new Coding(){
    								system = "http://",
    								code = "3637",
    								display = "Gene",
    							},
    						},
    					},
    					valueCodeableConcept = new Valuecodeableconcept(){
    						coding = new Coding[] {
    							new Coding(){
    								system = "http://",
    								code = "",
    								display = "CYP",
    							},
    						},
    					},
    				},
    			},
    		};
    		var str = JsonConvert.SerializeObject( obj, Formatting.Indented );
    		Console.WriteLine(str);
    	}
    }
    
        public class Rootobject
        {
            public string resourceType { get; set; }
            public Code code { get; set; }
            public Subject subject { get; set; }
            public string valueString { get; set; }
            public Component[] component { get; set; }
        }
    
        public class Code
        {
            public Coding[] coding { get; set; }
            public string text { get; set; }
        }
    
        public class Coding
        {
            public string system { get; set; }
            public string code { get; set; }
            public string display { get; set; }
        }
    
        public class Subject
        {
            public string reference { get; set; }
            public string display { get; set; }
        }
    
        public class Component
        {
            public Code2 code { get; set; }
            public Valuecodeableconcept valueCodeableConcept { get; set; }
        }
    
        public class Code2
        {
            public Coding[] coding { get; set; }
        }
    
        public class Valuecodeableconcept
        {
            public Coding[] coding { get; set; }
        }
