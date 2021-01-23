    System.Type oType = default(System.Type);
    System.Reflection.Assembly oAssembly = default(System.Reflection.Assembly);
    dynamic oObject = null;
    oAssembly = Assembly.LoadFrom(path);
    oType = oAssembly.GetType("LogicValidator");
    oObject = Activator.CreateInstance(oType);
    oObject.Initialise("param1", "param2", "param3", AuditTrail, UserInfo, workingDir);
    Console.WriteLine("Begin processing...");
    oObject.ProcessBatch(cm_uid);
