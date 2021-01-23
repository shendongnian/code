    var oAssembly = Assembly.LoadFrom(path);
    var oType = oAssembly.GetType("LogicValidator");
    IProcessor oObject = Activator.CreateInstance(oType);
    oObject.Initialise("param1", "param2", "param3", AuditTrail, UserInfo, workingDir);
    Console.WriteLine("Begin processing...");
    oObject.ProcessBatch(cm_uid);  
