    try
    {
        //Some Code...
    }
    catch (WebException err)
    {
        throw new LicenseException("This was really bad!", err);
    }
    catch (Exception err)
    {
        err.Data.Add("some-info", 123);
        logFramework.Log(err);
        throw;
    }
