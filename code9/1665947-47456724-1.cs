    using System;
    using System.Linq;
    using System.IO;
    using System.Reflection;
    
    namespace Your.Name.Space
    {
    	static partial class Program
    	{
    		static Program()
    		{
			    //! Generated file. Do not edit. Check the .tt file instead!
                LoadAssemblyIfNecessary("HostApp.dll");
                LoadAssemblyIfNecessary("Dependency1.dll");
                LoadAssemblyIfNecessary("Dependency2.dll");
                LoadAssemblyIfNecessary("Modul1.exe");
    		}
    
    	    private static readonly AssemblyName[] REFS = Assembly.GetExecutingAssembly().GetReferencedAssemblies();
    	    private static readonly string APP = Path.GetFileName(System.Windows.Forms.Application.ExecutablePath);
    
    		private static void LoadAssemblyIfNecessary(string name)
    		{
    		    if (string.Equals(name, APP, StringComparison.InvariantCultureIgnoreCase)) return;
    		    
    		    if (!REFS.Any(x => x.Name.StartsWith(Path.GetFileNameWithoutExtension(name), StringComparison.InvariantCultureIgnoreCase)))
    			{
                    AppDomain.CurrentDomain.Load(Path.GetFileNameWithoutExtension(name));
    			}
    		}
    	}
    }
