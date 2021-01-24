cs
using System;
using DtsRuntime = Microsoft.SqlServer.Dts.Runtime;
using DtsWrapper = Microsoft.SqlServer.Dts.Pipeline.Wrapper;
public void Main()
{
	string pkgLocation;
	DtsRuntime.Package pkg;
	DtsRuntime.Application app;
	DtsRuntime. DTSExecResult pkgResults;
	pkgLocation =
	  @"D:\Test\Package 1.dtsx";
	app = new DtsRuntime.Application();
	pkg = app.LoadPackage(pkgLocation, null);
	//List Executables (Tasks)
	foreach(DtsRuntime.Executable tsk in pkg.Executables)
	{
		DtsRuntime.TaskHost TH = (DtsRuntime.TaskHost)tsk;
		MessageBox.Show(TH.Name + "\t" + TH.HostType.ToString());
		//Data Flow Task components
		if (TH.InnerObject.ToString() == "System.__ComObject")
		{
			try
			{
				DtsWrapper.MainPipe m = (DtsWrapper.MainPipe)TH.InnerObject;
				DtsWrapper.IDTSComponentMetaDataCollection100 mdc = m.ComponentMetaDataCollection;
				foreach (DtsWrapper.IDTSComponentMetaData100 md in mdc)
				{
					MessageBox.Show(TH.Name.ToString() + " - " + md.Name.ToString());
				}
			}
			catch {
            // If it is not a data flow task then continue foreach loop
			}
			
		}
					  
	}
	//Event Handlers
	foreach(DtsRuntime.DtsEventHandler eh in pkg.EventHandlers)
	{
		MessageBox.Show(eh.Name + " - " + CM.HostType);
					   
	}
	//Connection Manager
	foreach(DtsRuntime.ConnectionManager CM in pkg.Connections)
	{
		MessageBox.Show(CM.Name + " - " + CM.HostType);
	}
	//Parameters
	foreach (DtsRuntime.Parameter Param in pkg.Parameters)
	{
		MessageBox.Show(Param.Name + " - " + Param.DataType.ToString());
	}
	//Variables
	foreach (DtsRuntime.Variable Var in pkg.Variables)
	{
		MessageBox.Show(Var.Name + " - " + Var.DataType.ToString());
	}
	//Precedence Constraints
	foreach (DtsRuntime.PrecedenceConstraint PC in pkg.PrecedenceConstraints)
	{
		MessageBox.Show(PC.Name);
	}
}
### References
- [Loading and Running a Local Package Programmatically](https://docs.microsoft.com/en-us/sql/integration-services/run-manage-packages-programmatically/loading-and-running-a-local-package-programmatically?view=sql-server-2017)
-------------------
## Update 2 - SSISPackageExplorer Project @ 2019-07-10
I starte a small project called SSISPackageExplorer on Git-Hub which allow the user to read the package objects in a TreeView, It is very basic right now but i will try to improve it in a while:
- [GitHub - SSISPackageExplorer](https://github.com/HadiFadl/SSISPackageExplorer)
[![enter image description here][2]][2]
  [1]: https://i.stack.imgur.com/XKpvc.png
  [2]: https://i.stack.imgur.com/AT603.png
