    public bool ShowEditBasedOnRole()
    {
        if (Roles.IsUserInRole("Editor"))
        {
            return true;
        }
        else
        {
            return false;
        }
    }
