     private bool hasUpdate;
     public bool HasUpdate
     {
        {
            return hasUpdate;
        }
        set
        {
            // the last bool param indicates whether or not to broadcast a message to all interested parties. 
            Set(nameof(HasUpdate), ref hasUpdate, value, true);
        }
    }
