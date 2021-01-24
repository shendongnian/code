    var bodyXmlPart = @"Hi please see below client " +
                      "<ac_application>" +
                      "    <primary_applicant_data>" +
                      "       <first_name>Ross</first_name>" +
                      "       <middle_name></middle_name>" +
                      "       <last_name>Geller</last_name>" +
                      "       <ssn>123456789</ssn>" +
                      "    </primary_applicant_data>" +
                      "</ac_application> thank you, \n john ";
     StringBuilder pattern = new StringBuilder();
     Regex regex = new Regex(@"<\?xml.*\?>", RegexOptions.Singleline);
     var match = regex.Match(bodyXmlPart);
     if (match.Success) // There is an xml declaration
     {
         pattern.Append(@"<\?xml.*");
     }
     Regex regexFirstTag = new Regex(@"\s*<(\w+:)?(\w+)>", RegexOptions.Singleline);
     var match1 = regexFirstTag.Match(bodyXmlPart);
     if (match1.Success) // xml has body and we got the first tag
     {
         pattern.Append(match1.Value.Trim().Replace(">",@"\>" + ".*"));
         string firstTag = match1.Value.Trim();
         Regex regexFullXmlBody = new Regex(pattern.ToString() + @"<\/" + firstTag.Trim('<','>') + @"\>", RegexOptions.None);
         var matchBody = regexFullXmlBody.Match(bodyXmlPart);
         if (matchBody.Success)
         {
            string xml = matchBody.Value;
         }
     }
