    var idn = new System.Globalization.IdnMapping();
    idn.UseStd3AsciiRules = true;
    idn.AllowUnassigned = false;
    string encodedFqdn = idn.GetAscii(fqdn);
    var dnsName = new GeneralName(GeneralName.DnsName, encodedFqdn);
