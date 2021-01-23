    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using System.Security;
    using System.Security.Permissions;
    using System.Text;
    using System.Threading.Tasks;
    
    namespace Sandboxes1
    {
    	class Program
    	{
    		static void Main(string[] args)
    		{
    			
    
    			var person = new Person();
    			Console.WriteLine("[{0}] Person's current name: {1}", AppDomain.CurrentDomain.FriendlyName, person.Name);
    
    			var program = new Program();
    
    			var customDomain = program.CreateDomain();
    			var result = program.Execute(customDomain, (x) =>
    			{
    				Console.WriteLine("[{0}] Inside delegate", AppDomain.CurrentDomain.FriendlyName);
    				var type = x.GetType();
    				var propertyInfo = type.GetProperty("Name");
    				var method = propertyInfo.GetMethod;
    				var res = method.Invoke(x, null) as string;
    
    				dynamic d = x;
    				d.Name = "Fozzy Bear";
    				Console.WriteLine("[{0}] delegate changed person's name to- {1}", AppDomain.CurrentDomain.FriendlyName, d.Name);
    
    				return res;
    			}, person);
    			Console.WriteLine("[{0}] Result: {1}", AppDomain.CurrentDomain.FriendlyName, result);
    			Console.WriteLine("[{0}] Person's current name: {1}", AppDomain.CurrentDomain.FriendlyName, person.Name);
    			Console.ReadLine();
    		}
    
    		public object Execute(AppDomain domain, Func<object, object> toExecute, params object[] parameters)
    		{
    			var t = typeof(Proxy); // add me
    			var args = new object[] {toExecute, parameters};
    			var proxy = domain.CreateInstanceAndUnwrap(t.Assembly.FullName, t.FullName, false,
    				BindingFlags.Default, 
    				null,
    				args,
    				null,
    				null) as Proxy; // add me
    			
    			//var proxy = new Proxy(toExecute, parameters);
    			var result = proxy.Invoke(domain);
    			return result;
    		}
    
    		private AppDomain CreateDomain()
    		{
    			var appDomainSetup = new AppDomainSetup()
    			{
    				ApplicationBase = AppDomain.CurrentDomain.BaseDirectory,
    				ApplicationName = "UntrustedAppDomain"
    			};
    
    			// Set up permissions
    			var permissionSet = new PermissionSet(PermissionState.None);
    			permissionSet.AddPermission(new SecurityPermission(PermissionState.Unrestricted));
    			permissionSet.AddPermission(new ReflectionPermission(PermissionState.Unrestricted));
    
    			// Create the app domain.
    			return AppDomain.CreateDomain("UntrustedAppDomain", null, appDomainSetup, permissionSet);
    		}
    
    		private sealed class Proxy : MarshalByRefObject
    		{
    			private Delegate method;
    			private object[] args;
    			private object result;
    
    			public Proxy(Delegate method, params object[] parameters)
    			{
    				Console.WriteLine("[{0}] Proxy()", AppDomain.CurrentDomain.FriendlyName);
    				this.method = method;
    				this.args = parameters;
    			}
    
    			public object Invoke(AppDomain customDomain)
    			{
    				Console.WriteLine("[{0}] Invoke()", AppDomain.CurrentDomain.FriendlyName);
    
    				customDomain.DoCallBack(Execute);
    				return this.result;
    			}
    
    			private void Execute()
    			{
    				Console.WriteLine("[{0}] Execute()", AppDomain.CurrentDomain.FriendlyName);
    
    				this.result = this.method.DynamicInvoke(this.args);
    			}
    		}
    	}
    
    	[Serializable]
    	public class Person
    	{
    		private string _name;
    
    		public Person()
    		{
    			Name = "Test Person";
    		}
    
    		public string Name
    		{
    			get
    			{
    				Console.WriteLine("[{0}] Person.getName()", AppDomain.CurrentDomain.FriendlyName);
    				return _name;
    			}
    			set { _name = value; }
    		}
    	}
    }
