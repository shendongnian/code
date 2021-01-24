    var bodyXmlPart = @"Hi please see below client <?xml version=""1.0"" encoding=""UTF-8""?>" +
          "<ac_application>" +
          "    <primary_applicant_data>" +
          "       <first_name>Ross</first_name>" +
          "       <middle_name></middle_name>" +
          "       <last_name>Geller</last_name>" +
          "       <ssn>123456789</ssn>" +
          "    </primary_applicant_data>" +
          "</ac_application> thank you, \n john ";
    
    Regex regex = new Regex(@"<\?xml.*\?>", RegexOptions.Singleline);
    var match = regex.Match(bodyXmlPart);
    if (match.Success) // There is an xml in the body
    {
        var bodyXmlPart1 = bodyXmlPart.Substring(bodyXmlPart.IndexOf(match.Value) + match.Value.Length);
        Regex regexFirstTag = new Regex(@"^\s*<(\w+:)?(\w+)>", RegexOptions.Singleline);
        var match1 = regexFirstTag.Match(bodyXmlPart1);
        if (match1.Success) // xml has body and we got the first tag
        {
            string firstTag = match1.Value;
            Regex regexFullXmlBody = new Regex(@"(?<xml>\<\?xml.*<\/" + firstTag.Trim('<','>') + @"\>)", RegexOptions.None);
            var matchBody = regexFullXmlBody.Match(bodyXmlPart);
            if (matchBody.Success)
            {
                string xml = matchBody.Value;
            }
         }
    }
