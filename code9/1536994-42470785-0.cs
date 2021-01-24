    class ApplicationDataHelper
    {
        LookupData GetApplicationLookupData()
        {
            return HttpContext.Current.Application["lookup"];
        }
    }
