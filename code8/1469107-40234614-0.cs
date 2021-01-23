    //Show/Hide stats
    void showStats(bool enableStats)
    {
        Assembly asm = Assembly.GetAssembly(typeof(Editor));
        Type type = asm.GetType("UnityEditor.GameView");
        if (type != null)
        {
            MethodInfo gameViewFunction = type.GetMethod("GetMainGameView", BindingFlags.Static |
                BindingFlags.NonPublic);
    
            object gameViewInstance = gameViewFunction.Invoke(null, null);
    
    
            FieldInfo getFieldInfo = type.GetField("m_Stats", BindingFlags.Instance |
                                                   BindingFlags.NonPublic | BindingFlags.Public);
    
            getFieldInfo.SetValue(gameViewInstance, enableStats);
        }
    }
    
    //Returns true if stats is enabled
    bool statsIsEnabled()
    {
        Assembly asm = Assembly.GetAssembly(typeof(Editor));
        Type type = asm.GetType("UnityEditor.GameView");
        if (type != null)
        {
            MethodInfo gameViewFunction = type.GetMethod("GetMainGameView", BindingFlags.Static |
                BindingFlags.NonPublic);
    
            object gameViewInstance = gameViewFunction.Invoke(null, null);
    
    
            FieldInfo getFieldInfo = type.GetField("m_Stats", BindingFlags.Instance |
                                                   BindingFlags.NonPublic | BindingFlags.Public);
    
            return (bool)getFieldInfo.GetValue(gameViewInstance);
        }
        return false;
    }
