    var oAssembly = Assembly.LoadFrom(path);
    var oType = oAssembly.GetType("LogicValidator");
    var oObject = Activator.CreateInstance(oType);
    var oInitialiseMethod = oType.GetMethod("Initialise"); //See note below the code.
    var oProcessBatchMethod = oType.GetMethod("ProcessBatch"); //See note below the code.
    oInitialiseMethod.Invoke(oObject, "param1", "param2", "param3", AuditTrail, UserInfo, workingDir);
    Console.WriteLine("Begin processing...");
    oObject.ProcessBatch(cm_uid);
