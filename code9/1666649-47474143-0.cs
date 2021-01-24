        private void GetCalendar(string mailAddressOfCalendar)
        {
            Outlook.Application oApp = new Outlook.Application();
            Outlook.AddressEntry addrEntry = oApp.Session.CurrentUser.AddressEntry;
            if (addrEntry.Type == "EX")
            {
                Outlook.Recipient recip = oApp.Session.CreateRecipient(mailAddressOfCalendar);
                if (recip.Resolve())
                {
                    try
                    {
                        Outlook.Folder folder =
                            oApp.Session.GetSharedDefaultFolder(
                            recip, Outlook.OlDefaultFolders.olFolderCalendar)
                            as Outlook.Folder;
                        ForceUpdateAddOnCalaendar(folder);
                    }
                    catch (Exception e)
                    {
                        MessageBox.Show("Could not open calendar",
                            e.ToString(),
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                    }
                }
            }
        }
