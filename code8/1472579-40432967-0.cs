				public class MyClass
				{
					private string _HelloWorld;
					public string HelloWorld
					{
						get {return _HelloWorld;}
						set {_HelloWorld = value;}
					}
					
					public void MyMethod
					{
						TestC();
					}
					
					public void TestA()
					{
						TestB();
					}
					
					public void TestB()
					{
						Console.WriteLine(HelloWorld);
					}
					
					public void TestC()
					{
						TestA();
					}
					
				}
----------
				public class MyClass2
				{
					private string _HelloWorld;
					
					public void MyMethod
					{
						TestC();
					}
					public void TestC()
					{
						TestA();
					}
					
					public void TestA()
					{
						TestB();
					}
					
					public void TestB()
					{
						Console.WriteLine(HelloWorld);
					}
					
					public string HelloWorld
					{
						get {return _HelloWorld;}
						set {_HelloWorld = value;}
					}
				}
