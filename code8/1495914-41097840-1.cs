    private dynamic GetNextSet(CleanupModel.Tables table)
    {
        switch (table)
        {
            case CleanupModel.Tables.Version: return context.Page;
            //More cases
                    
            default: return null;
        }
    }
