    var installDate = new DateTime(2016, 12, 28); // replace with registry value
    var useDate = new DateTime(2017, 01, 31); // replace with registry value
    var inputs = installDate.ToString("yyyy-MM-dd") + "," + useDate.ToString("yyyy-MM-dd");
    using (var sha = new System.Security.Cryptography.SHA256CryptoServiceProvider())
    {
        var hash = sha.ComputeHash(Encoding.ASCII.GetBytes(inputs));
    }
