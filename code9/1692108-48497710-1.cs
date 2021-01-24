    protected override void OnStart()
    {
        base.OnStart();
        if (ContextCompat.CheckSelfPermission(this, permission) != Permission.Granted)
        {
            ActivityCompat.RequestPermissions(this, new String[] { Manifest.Permission.AccessCoarseLocation, Manifest.Permission.AccessFineLocation }, 0);
        }
        else
        {
            System.Diagnostics.Debug.WriteLine("Permission Granted!!!");
        }
    }
