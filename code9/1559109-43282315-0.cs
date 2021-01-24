    Queryable<DeviceMinimal> devices =
	   from device in db.Devices
	   where device.AccountId = accountId
	   select new DeviceMinimal
	   {
		   Id = device.Id,
	       Name = device.Name,
		   LicenseIsValid =
			LicenseHelper.IsLicenseEnabledAndValid(checkForLicense).Invoke(device.Licence)
	   };
    public static Func<License, bool> IsLicenseEnabledAndValid(bool checkForLicense)
    {
	    return result => !checkForLicense ||
		    result != null && (
   		   !result.TrialStarted
  		    // && 12+ licensing rules
		  );
    }
