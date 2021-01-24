    var customers = customersRaw.SelectNodes("tlp:WorkUnit", namespaceManager);
    if (customers != null)
    {
        foreach (XmlNode customer in customers)
        {
            var childNodes = customer.SelectNodes("./*");
            if(childNodes != null)
            {
                foreach(XmlNode childNode in childNodes)
                {
                    if (Logger.IsDebugEnabled)
                    {
                        Logger.Debug(customerName.InnerText);
                    }
                }
            }
        }
    }
