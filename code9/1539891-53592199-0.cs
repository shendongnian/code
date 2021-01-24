    protected void btnSendMessage_Click(object sender, EventArgs e)
        {
            string searchbase = ddlZaal.SelectedItem.Text; //This is a dropdownlist to select an OU
            DirectoryEntry entry = new DirectoryEntry("LDAP://OU=" + searchbase + ",OU=YourOU,OU=YourSubOU," + Variables.Domain + ""); //Variables.Domain is specified in the Web.config
            DirectorySearcher mySearcher = new DirectorySearcher(entry);
            mySearcher.Filter = ("(objectClass=computer)");
            foreach (SearchResult result in mySearcher.FindAll())
            {
                DirectoryEntry directoryObject = result.GetDirectoryEntry();
                string computernaam = directoryObject.Properties["Name"].Value.ToString();
                lstComputers.Items.Add(computernaam); //This is a listbox that shows the computernames. To each computer a message is sent.
                string pingnaam = computernaam + "dns.suffix"; //Might be necessary for connecting to the computes in the domain
                string MessageToSend = txtMessageToSend.Text; //The text in this textbox will be the messagetext
                Process process = new Process();
                ProcessStartInfo psi = new ProcessStartInfo(@"C:\inetpub\wwwroot\PsExec.exe"); //Location of PsExec.exe on the webserver that hosts the web-application.
                psi.UseShellExecute = false;
                psi.RedirectStandardOutput = true;
                psi.RedirectStandardError = true;
                psi.RedirectStandardInput = true;
                psi.WindowStyle = ProcessWindowStyle.Minimized;
                psi.CreateNoWindow = true;
                psi.Arguments = "/accepteula -s -i \\\\" + pingnaam + " cmd /c msg.exe * " + MessageToSend;
                process.StartInfo = psi;
                process.Start();
            }
        }
