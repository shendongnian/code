        static void Main(string[] args)
        {
            Console.WriteLine("Plus API - Service Account");
            Console.WriteLine("==========================");
            String serviceAccountEmail = "xxxx@xxxx-xxxx.xx.gserviceaccount.com";
            var certificate = new X509Certificate2(AppDomain.CurrentDomain.BaseDirectory +
                 "xxxxxxxxxx.p12", "notasecret", X509KeyStorageFlags.Exportable);
            ServiceAccountCredential credential = new ServiceAccountCredential(
               new ServiceAccountCredential.Initializer(serviceAccountEmail)
               {
                   Scopes = new[] { GmailService.Scope.MailGoogleCom },
                   User = "xxxx@xxxxxxx.net"//ur Gsuit Id
               }.FromCertificate(certificate));
            // Create the service.
            var service = new GmailService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = credential,
                ApplicationName = "xxxxx",
            });
            var re = service.Users.Messages.List("me");
            re.LabelIds = "INBOX";
            re.Q = "is:unread"; //only get unread;
            var res = re.Execute();
            if (res != null && res.Messages != null)
            {
             
                foreach (var email in res.Messages)
                {
                    var emailInfoReq = service.Users.Messages.Get("me", email.Id);
                    var emailInfoResponse = emailInfoReq.Execute();
                    if (emailInfoResponse != null)
                    {
                        String from = "";
                        String date = "";
                        String subject = "";
                        String body = "";
                        //loop through the headers and get the fields we need...
                        foreach (var mParts in emailInfoResponse.Payload.Headers)
                        {
                            if (mParts.Name == "Date")
                            {
                                date = mParts.Value;
                            }
                            else if (mParts.Name == "From")
                            {
                                from = mParts.Value;
                            }
                            else if (mParts.Name == "Subject")
                            {
                                subject = mParts.Value;
                            }
                            if (date != "" && from != "")
                            {
                                if (emailInfoResponse.Payload.Parts == null && emailInfoResponse.Payload.Body != null)
                                    body = DecodeBase64String(emailInfoResponse.Payload.Body.Data);
                                else
                                    body = GetNestedBodyParts(emailInfoResponse.Payload.Parts, "");
                                //now you have the data you want....
                            }
                        }
                        //Console.Write(body);
                        Console.WriteLine("{0}  --  {1}  -- {2}", subject, date, email.Id);
                        //Console.ReadKey();
                    }
                }
            }
        }
        static String DecodeBase64String(string s)
        {
            var ts = s.Replace("-", "+");
            ts = ts.Replace("_", "/");
            var bc = Convert.FromBase64String(ts);
            var tts = Encoding.UTF8.GetString(bc);
            return tts;
        }
        static String GetNestedBodyParts(IList<MessagePart> part, string curr)
        {
            string str = curr;
            if (part == null)
            {
                return str;
            }
            else
            {
                foreach (var parts in part)
                {
                    if (parts.Parts == null)
                    {
                        if (parts.Body != null && parts.Body.Data != null)
                        {
                            var ts = DecodeBase64String(parts.Body.Data);
                            str += ts;
                        }
                    }
                    else
                    {
                        return GetNestedBodyParts(parts.Parts, str);
                    }
                }
                return str;
            }
        }
