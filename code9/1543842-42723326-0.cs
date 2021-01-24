    MethodInfo dynMethod = typeof(BuildPipeline).GetMethod("IsBuildTargetSupported", BindingFlags.Static | BindingFlags.NonPublic);
    if(Convert.ToBoolean(dynMethod.Invoke(this, new object[] { BuildTarget.PS4 })))
    {
        Debug.Log("PS4 Supported");
    }
    if (Convert.ToBoolean(dynMethod.Invoke(this, new object[] { BuildTarget.Android })))
    {
        Debug.Log("Android Supported");
    }
    //etc
