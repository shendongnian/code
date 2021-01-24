    public override Func<JObject, dynamic, string> version => (jobject, parameters) =>
    {
        Func<VersionInfo, VersionInfo>[] a = { null, _radio.Version1 = v, 
                    v => _radio.Version2 = v, v => _radio.Version3 = v,
                    v => _radio.Version4 = v, null, v => _radio.Version6 = v };
        var q = from n in new[] { 1, 2, 3, 4, 6 }
                let j = jobject["Version" + n] where j != null
                select a[n](new VersionInfo(j.Value<string>()));
        return q.Count() > 0 ? GenerateSuccess() : GenerateUnsuccessful(" try again.");
    };
