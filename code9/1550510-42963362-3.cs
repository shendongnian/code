    public override Func<JObject, dynamic, string> version => (jobject, parameters) =>
    {
        var q = from n in "12346"
                let j = jobject["Version" + n]
                where j != null
                select new { n, v = new VersionInfo(j.Value<string>()) };
        foreach (var a in q)
            switch (a.n) {
                case '1': _radio.Version1 = a.v; break;
                case '2': _radio.Version2 = a.v; break;
                case '3': _radio.Version3 = a.v; break;
                case '4': _radio.Version4 = a.v; break;
                case '6': _radio.Version6 = a.v; break;
            }            
        return q.Any() ? GenerateSuccess() : GenerateUnsuccessful(" try again.");
    };
