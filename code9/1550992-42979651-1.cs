        public Func<JObject, dynamic, string> VersionMethod = (jobject, parameters) =>
        {
            bool hasValidObject = false;
             _livetv.SoftwareVersion = GetVersionInfo(jobject, "swVersion", ref hasValidObject);
             _livetv.HardwareVersion = GetVersionInfo(jobject, "hwVersion", ref hasValidObject); 
             _livetv.LTV2Version = GetVersionInfo(jobject, "ltvVersion", ref hasValidObject);
             _livetv.LTV3Version = GetVersionInfo(jobject, "ltv3Version", ref hasValidObject); 
             _ivetv.KAVersion = GetVersionInfo(jobject, "cricVersion", ref hasValidObject);  
             _livetv.BasebandVersion = GetVersionInfo(jobject, "bbVersion", ref hasValidObject); 
             
            if (hasValidObject)
            {
                return GenerateSuccessful();
            }
            return GenerateUnsuccessful(
                "Unable to parse version from request, try again.");
        };
