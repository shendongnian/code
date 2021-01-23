      public static string Parsing(string certSubject)
        {
            string[] strArr = certSubject.Split(new char[] { '=', ' ', '\t', '\n',',' });
        string subject = "";
        for (int i = 0; i < strArr.Length; i++)
        {
            if (strArr[i].Equals("cn", StringComparison.InvariantCultureIgnoreCase))
            {
                if ((i + 1) < strArr.Length)
                {
                    subject = strArr[i + 1];
                    break;
                }
            }
        }
        if (subject.Length > 0)
        {
            return subject;
        }
        return "Can't parse";
    }
