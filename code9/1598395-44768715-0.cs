        static async Task ExecuteEmailer()
        {
            var settings = ConfigurationManager.AppSettings;
            var fromAddr = settings["fromaddr"];
            var toAddr = settings["toaddr"];
            var trans = new Transmission();
            var to = new Recipient
            {
                Address = new Address
                {
                    Email = toAddr
                },
                SubstitutionData = new Dictionary<string, object>
                {
                    {"firstName", "Stranger"}
                }
            };
            trans.Recipients.Add(to);
            trans.SubstitutionData["firstName"] = "Sir or Madam";
            trans.Content.From.Email = fromAddr;
            trans.Content.Subject = "SparkPost sending attachment using template";
            trans.Content.Text = "Greetings {{firstName or 'recipient'}}\nHello from C# land.";
            //Add attachments to transmission object
            trans.Content.Attachments.Add(new Attachment()
            {
                Data = Convert.ToBase64String(System.IO.File.ReadAllBytes(@"C:\PathToFile\ExcelFile.xlsx")),
                Name = "ExcelFile.xlsx",
                Type = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet"
            });
            Console.Write("Sending mail...");
            var client = new Client(settings["apikey"]);
            client.CustomSettings.SendingMode = SendingModes.Sync;
            //retrieve template html and set Content.Html
            var templateResponse = await client.Templates.Retrieve("template-email-test");
            trans.Content.Html = templateResponse.TemplateContent.Html;
            //Send transmission 
            var response = client.Transmissions.Send(trans);
            Console.WriteLine("done");
        }
