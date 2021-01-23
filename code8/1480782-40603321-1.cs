     public static bool CanReadKey(this RegistryPermission reg, string key)
        {
            try
            {
                RegistryPermission r = new RegistryPermission(RegistryPermissionAccess.Read, key);
                r.Demand();
                return true;
            }
            catch (SecurityException)
            {
                return false;
            }
        }
    
    foreach (var key in keys){
        if(!CanReadKey(registry, key)){ continue; }
    
        // do stuff ...
    }
    
