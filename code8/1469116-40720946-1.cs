    protected override void Dispose(bool disposing)
    {
        if (disposing && RoleManager != null)
        {
            RoleManager.Dispose();
            RoleManager = null;
        }
        if (disposing)
        {
            context.Dispose();
        }
        base.Dispose(disposing);
    }
