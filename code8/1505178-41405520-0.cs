    namespace SimpleScripts
	{   
	    public class MyScriptMul5 : ScriptingInterface.IScriptType1
	    {
	        public string RunScript(ScriptingInterface.IServiceProvider serviceProvider, int value)
	        {
	            System.Console.WriteLine("Hello World! This works!");
	            serviceProvider.Messenger.SendMessage("Test");
	        }
	    }
	}
