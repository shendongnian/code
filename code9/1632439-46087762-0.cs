                var DSNFileContents = File.ReadAllLines(WebConfigurationManager.AppSettings["AppPath"] + @"\App.DSN");//reads DSN into a string array
                //get UID
                string uid = DSNFileContents.Where(line => line.StartsWith("UID")).First().Substring(4);//get UID from array
                //test if uid has quotes around it
                if (uid[0] == '"' && uid[uid.Length - 1] == '"')
                {
                    //if to starts with a quote AND ends with a quote, remove the quotes at both ends
                    uid = uid.Substring(1, uid.Length - 2);
                }
                //get server
                string server = DSNFileContents.Where(line => line.StartsWith("SERVER")).First().Substring(7);//get the server from the array
                //test if server has quotes around it
                if (server[0] == '"' && server[server.Length - 1] == '"')
                {
                    //if to starts with a quote AND ends with a quote, remove the quotes at both ends
                    server = server.Substring(1, server.Length - 2);
                }
         
                //THIS WON'T WORK 100% FOR ANYONE ELSE. WILL NEED TO BE ADAPTED
                //test if PWD is encoded
                string password = "";
                if (DSNFileContents.Where(line => line.StartsWith("PWD")).First().StartsWith("PWD=/Crypto:"))
                {
                    string secretkey = "<secret>";
                    string IV = "<alsoSecret>";
                    byte[] encoded = Convert.FromBase64String(DSNFileContents.Where(line => line.StartsWith("PWD")).First().Substring(12));
                    //THIS LINE IN PARTICULAR WILL NOT WORK AS DecodeSQLPassword is a private method I wrote to break the other applications encryption
                    password = DecodeSQLPassword(encoded, secretkey, IV);
                }
                else
                {
                    //password was not encrypted
                    password = DSNFileContents.Where(line => line.StartsWith("PWD")).First().Substring(4);
                }
                //build connection string
                SqlConnectionStringBuilder cString = new SqlConnectionStringBuilder();
                cString.UserID = uid;
                cString.Password = password;
                cString.InitialCatalog = "mydatabase";
                cString.DataSource = server;
                cString.ConnectTimeout = 30;
                //statProps is a static class that I have created to hold some variables that are used globally so that I don't have to I/O too much.
                statProps.ConnectionString = cString.ConnectionString;
