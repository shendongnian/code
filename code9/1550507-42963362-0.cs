    public static Func<JObject, dynamic, string> version => (jobject, parameters) =>
    {
        bool hasValidObject = false;
        foreach (char n in "12346")
        {
            var jObj = jobject["Version" + n];
            if (jObj != null)
            {
                var versionInfo = new VersionInfo(jObj.Value<string>());
                switch (n)
                {
                    case '1': _radio.Version1 = versionInfo; break;
                    case '2': _radio.Version2 = versionInfo; break;
                    case '3': _radio.Version3 = versionInfo; break;
                    case '4': _radio.Version4 = versionInfo; break;
                    case '6': _radio.Version6 = versionInfo; break;
                }
                hasValidObject = true;
            }
        }
        return hasValidObject ? GenerateSuccess() : GenerateUnsuccessful(" try again.");
    };
