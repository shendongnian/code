    EventHandler method = async (sender, e) =>
    {
        try
        {
            SomeAction();
            btnLog.TouchUpInside -= method;
        }
        catch (Exception exe)
        {
            Log(exe.message);
        }
    };
    btnLog.TouchUpInside += method;
