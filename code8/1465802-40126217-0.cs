    [CustomAction]
    public static ActionResult SetRegistryItems(Session session)
    {
        session.Log("Begin SetRegistryItems");
        try
        {
            // this private method actually does manipulation with registry
            SetRegistry();
        }
        catch (Exception e)
        {
            session.Log(e.ToString());
        }
        return ActionResult.Success;
    }
