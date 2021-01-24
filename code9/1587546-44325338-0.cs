    <#@ template  debug="true" hostSpecific="true" #>
    <#@ output extension=".cs" #>
    <#@ include file="TemplateFileManagerV2.1.ttinclude" #>
    <#@ Assembly Name="System.Core" #>
    <#@ Assembly Name="System.Windows.Forms" #>
    <#@ assembly name="EnvDTE" #>
    <#@ import namespace="System" #>
    <#@ import namespace="System.IO" #>
    <#@ import namespace="System.Diagnostics" #>
    <#@ import namespace="System.Linq" #>
    <#@ import namespace="System.Collections" #>
    <#@ import namespace="System.Collections.Generic" #>
    <#@ import namespace="EnvDTE" #>
    <#
    	string absolutePath = Host.ResolvePath("..\\Database.designer.cs");
    	string[] contents = File.ReadAllLines(absolutePath);
    
    	List<string> selectedContent = new List<string>();
    	string[] separators = new string[] { " " };
    
    	foreach (var csFileRow in contents)
    	{
    		if (csFileRow.Contains("public partial class"))
    		{
    			var tmpSplit = csFileRow.Split(' ');
    			var tmpString = tmpSplit[3]; // public partial class <targetClassName> (4th member)
    
    			if (tmpString.Contains("Result")) // Example: SearchRolesResult
    			{
    				selectedContent.Add(tmpString);
    			}
    		}
    	}
    
    	var manager = TemplateFileManager.Create(this);
    #>
    <#
    	foreach (var classItem in selectedContent)
    	{
    		manager.StartNewFile(classItem + ".cs");
    #>
    namespace Name.Space
    {
    	public partial class <#= classItem #>
    	{
    	}
    }
    
    <#
    		manager.EndBlock();
    	}
    	manager.Process();
    
    #>
