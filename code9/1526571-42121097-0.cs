    class ClassA
    {
	    public ClassA([CallerMemberName]string member = "", [CallerFilePath]string classFile = ""){
	        // when this class is instantiated I want to know "who" is creating an instance of it?
	        // In this case the answer should be 'ClassB'
			Console.WriteLine("Created using method {0} from file {1}", member, classFile);
	    }
	}
	
	class ClassB
	{
	    public void SomeFunc(){
	        // Do some stuff
	
	        var a = new ClassA();
	    }
	}
