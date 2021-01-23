    [System.Web.Services.WebMethod]
            public static List<string> returntxt1Data(string prefixText)
            {
                List<string> newlist1 = new List<string>();
    
                foreach (string a in List1)
                {
                    if (a.ToUpper().Contains(prefixText.ToUpper()))
                    {
                        newlist1.Add(a);
                    }
                }
                return newlist1;
            }
