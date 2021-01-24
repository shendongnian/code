    using Windows.Management.Deployment;
    
    var app = await GetAppByPackageFamilyNameAsync("Microsoft.WindowsCalculator_8wekyb3d8bbw");
    
    if(app != null)
    {
      await app.LaunchAsync();
    }    
    
    static async Task<AppListEntry> GetAppByPackageFamilyNameAsync(string packageFamilyName)
    {
        var pkgManager = new PackageManager();
        var pkg = pkgManager.FindPackagesForUser("", packageFamilyName).FirstOrDefault();
        if (pkg == null) return null;
        var apps = await pkg.GetAppListEntriesAsync();
        var firstApp = apps.FirstOrDefault();
        return firstApp;
    }
