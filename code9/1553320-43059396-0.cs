    DTE2 DTE = Package.GetGlobalService(typeof(EnvDTE.DTE)) as DTE2;
    var project = ((Array)DTE.ActiveSolutionProjects).GetValue(0) as Project;
    var  properties = project.Properties;
    var ot = properties.Item("OutputType").Value.ToString();
    prjOutputType po = (prjOutputType)Enum.Parse(typeof(prjOutputType), ot);
