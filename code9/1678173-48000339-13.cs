    string fileName = HostingEnvironment.MapPath("~/bin/Config/AppleValues.cs");
    var dynamicAsm = Utilities.BuildFileIntoAssembly(fileName);
    var dynamicApple = Utilities.GetTypeFromAssembly(dynamicAsm, typeof(Apple).FullName);
    var precompApple = new Apple();
    var updatedApple = Utilities.CopyProperties(dynamicApple, precompApple);
    // set static property
    Apple = updatedApple;
