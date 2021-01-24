    <#@ template language="C#" hostSpecific="true" debug="True" #>
    <#@ output extension="cs" #>
    <#@ assembly name="System.Core" #>
    <#@ assembly name="EnvDte" #>
    <#@ import namespace="System.Linq" #>
    <#@ import namespace="System.IO" #>
    <#@ import namespace="System.Collections.Generic" #>
    <#@ import namespace="System.Text.RegularExpressions" #>
    <#@ import namespace="System" #>
    <#
    
    	var visualStudio = (EnvDTE.DTE)(Host as IServiceProvider).GetService(typeof(EnvDTE.DTE));
    	var solution = (EnvDTE.Solution)visualStudio.Solution;
    	var projects = solution.Projects;
    
    	// Assume that the first item is the main project, the host app.
    	// Index is **NOT** zero-based!
    	var main = (EnvDTE.Project)projects.Item(1);
    	var p = main.Properties.Item("DefaultNamespace");
    	var ns = p.Value.ToString();
    
    #>
    using System;
    using System.Linq;
    using System.IO;
    using System.Reflection;
    
    namespace <# WriteLine(ns); #>
    {
    	static partial class Program
    	{
    		static Program()
    		{
			    //! Generated file. Do not edit. Check the .tt file instead!
    <#
    foreach(EnvDTE.Project proj in projects)
    {
    	if(proj.Properties == null || proj.Properties.Item("OutputFileName") == null)
    		continue;
    
    	EnvDTE.Property p2 = proj.Properties.Item("OutputFileName") as EnvDTE.Property;
    	WriteLine("            LoadAssemblyIfNecessary(\"" + p2.Value + "\");");
    }
    #>
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
