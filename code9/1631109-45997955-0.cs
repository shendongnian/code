    private static void Main(string[] args)
    		{
    			Example1();
    			Example2();
    			Example3();
    		}
    
    		public static void Example1()
    		{
    			Console.WriteLine("This example shows using copy with reflection. Minus of this method - u have to implement FULL copy for each class or u will copy only references to object properties");
    
    			//creating new parent class with some values
    			var parentClass = new ParentClass
    			{
    				Property1 = "qqq",
    				Property2 = 1,
    				ObjectProperty = new SomeClassWithObjectProperty
    				{
    					ObjectProperty = new SomeObjectClass {SomeProperty = "www"}
    				}
    			};
    
    			//crating new child class and copy REFERENCES to properties
    			var childClassReflection = new ChildClassReflection(parentClass);
    
    			//changing properties of parent
    			parentClass.Property1 = "rrr";
    			parentClass.Property2 = 2;
    			parentClass.ObjectProperty.ObjectProperty.SomeProperty = "eee";
    
    			//we will get OLD values for VALUE types and OLD values for REFERENCE types
    			//qqq 1 WWW
    			Console.WriteLine(childClassReflection.Property1 + " " + childClassReflection.Property2 + " " + childClassReflection.ObjectProperty.ObjectProperty.SomeProperty);
    		}
    
    		public static void Example2()
    		{
    			Console.WriteLine();
    			Console.WriteLine("This example shows using copy with reflection WITH FULL COPY");
    
    			//creating new parent class with some values
    			var parentClass = new ParentClass
    			{
    				Property1 = "qqq",
    				Property2 = 1,
    				ObjectProperty = new SomeClassWithObjectProperty
    				{
    					ObjectProperty = new SomeObjectClass {SomeProperty = "www"}
    				}
    			};
    
    			//crating new child class and copy REFERENCES to properties
    			var childClassReflection = new ChildClassReflectionWithFullCopy(parentClass);
    
    			//changing properties of parent
    			parentClass.Property1 = "rrr";
    			parentClass.Property2 = 2;
    			parentClass.ObjectProperty.ObjectProperty.SomeProperty = "eee";
    
    			//we will get OLD values for VALUE types and NEW values for REFERENCE types
    			//qqq 1 eee
    			Console.WriteLine(childClassReflection.Property1 + " " + childClassReflection.Property2 + " " + childClassReflection.ObjectProperty.ObjectProperty.SomeProperty);
    		}
    
    		public static void Example3()
    		{
    			//here i will show copy using AutoMapper
    		}
    	}
    
    
    	public class ChildClassReflection : ParentClass
    	{
    		public ChildClassReflection(ParentClass parentClass)
    		{
    			foreach (var p in ParentProperties)
    				p.SetMethod.Invoke(this, new[] {p.GetMethod.Invoke(parentClass, null)});
    		}
    
    		//do it only once for best performance
    		private static PropertyInfo[] ParentProperties { get; } = typeof(ParentClass).GetProperties().Where(c => c.CanRead && c.CanWrite).ToArray();
    	}
    
    	public class ChildClassReflectionWithFullCopy : ParentClass
    	{
    		public ChildClassReflectionWithFullCopy(ParentClass parentClass)
    		{
    			var parentClassLocal = JsonConvert.DeserializeObject<ParentClass>(JsonConvert.SerializeObject(parentClass));
    			foreach (var p in ParentProperties)
    				p.SetMethod.Invoke(this, new[] {p.GetMethod.Invoke(parentClassLocal, null)});
    		}
    
    		//do it only once for best performance
    		private static PropertyInfo[] ParentProperties { get; } = typeof(ParentClass).GetProperties().Where(c => c.CanRead && c.CanWrite).ToArray();
    	}
    
    	public class ParentClass
    	{
    		public string Property1 { get; set; }
    		public int Property2 { get; set; }
    		public SomeClassWithObjectProperty ObjectProperty { get; set; }
    	}
    
    	public class SomeClassWithObjectProperty
    	{
    		public SomeObjectClass ObjectProperty { get; set; }
    	}
    
    	public class SomeObjectClass
    	{
    		public string SomeProperty { get; set; }
    	}
