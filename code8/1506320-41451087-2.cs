    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;
    					
    namespace Rextester
    {
        public class Program
        {
            public static void Main(string[] args)
            {
                // real-world variables, keep them typed as base Message
                // to be able to silently replace them with different objects
                Message original1;
                Message original2;
                // let's construct some one-time readable messages
                {
                    var tmp1 = new OneTimeMessage();
                    tmp1.data["mom"] = "dad";
                    tmp1.data["cat"] = "dog";
                    original1 = tmp1;
                
                    var tmp2 = new OneTimeMessage();
                    tmp2.data["mom"] = "dad";
                    tmp2.data["cat"] = "dog";
                    original2 = tmp2;
                }
                // test1 - can't read twice
                Console.WriteLine("test0A:" + original1.GetData("mom"));
                //Console.WriteLine("test0B:" + original1.GetData("mom")); // fail
                // test2 - can read twice with Reader's help
                var backup1 = original2;
                using(var rd1 = new Reader(ref original2))
                {
                    Console.WriteLine("test1A:" + rd1.ReadSomething("mom"));
                }
        
                var backup2 = original2;
                using(var rd2 = new Reader(ref original2))
                {
                    Console.WriteLine("test1A:" + rd2.ReadSomething("mom"));
                    //^ ok - becase Reader replaced 'original2' with SafeMessage
                }
                // test3: Reader's ctor is intelligent
                // so no more SafeMessages created during future usage
                var backup3 = original2;
                using(var rd3 = new Reader(ref original2))
                {
                }
        
                var backup4 = original2;
                using(var rd4 = new Reader(ref original2))
                {
                }
                
                Console.WriteLine("checking for copies:" + (original2 == backup1));
                Console.WriteLine("checking for copies:" + (original2 == backup2));
                Console.WriteLine("checking for copies:" + (original2 == backup3));
                Console.WriteLine("checking for copies:" + (original2 == backup4));
            }
        }
    }
    
    public abstract class Message
    {
    	public abstract string GetData(string id);
    }
    
    public class OneTimeMessage : Message // this models your current one-time-readable message
    {
    	public IDictionary<string, string> data = new Dictionary<string, string>();
    
    	public override string GetData(string id)
    	{
    		var tmp = data[id];
    		data.Remove(id);
            // that's nonsense, but I want to show that you can't
            // read the same thing twice from this object
    		return tmp;
    	}
    }
    
    public class SafeMessage : Message
    {
    	public IDictionary<string, string> data;
    
    	public override String GetData(string id)
    	{
    		return data[id];
    	}
    	
    	public SafeMessage(Message msg)
    	{
    		// read out the full msg's data and store it
    		// since this is example, we can do it in a pretty simple way
    		// in your code that will probably be more complex
    		this.data = new Dictionary<string,string>(((OneTimeMessage)msg).data);
    	}
    }
    
    public class Reader : IDisposable
    {
    	private Message message;
    	public Reader(ref Message src)
    	{
    		src = src is SafeMessage ? src : new SafeMessage(src);
    		this.message = src;
    	}
    
    	public string ReadSomething(string id){ return message.GetData(id); }
    	public void Dispose(){ Close(); }
    	public void Close(){ message=null; Console.WriteLine("reader closed"); }
    }
