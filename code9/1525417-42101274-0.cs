    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            buildModule();
        }
        catch (Exception ex)
        {
            Exceptions.ProcessModuleLoadException(this, ex);
        }
    }
