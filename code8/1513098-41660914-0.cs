    public static string GetCertificateName(string certSubject)
    {
        //"CN=bbb1, OU=b, O=b, L=b, S=b, C=US"	
        System.Text.RegularExpressions.Regex regex;
        try
        {
            regex = new System.Text.RegularExpressions.Regex(@"CN\s*=\s*(?<name>\*?\.?\w*\.?\w+)");
            var match = regex.Match(certSubject);
            return match.Groups["name"].Value;
        }
        catch(Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
        return "Can't parse";
    } 
