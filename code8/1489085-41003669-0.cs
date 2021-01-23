        string advancedSearchTag = "MY FOOFOO Search";
        //SEARCH Function
        Search RunAdvancedSearch(Outlook.Application Application, string wordInSubject)
        {
            string scope = "Inbox";
            string filter = "urn:schemas:mailheader:subject LIKE \'%" + wordInSubject + "%\'";
            Outlook.Search advancedSearch = null;
            Outlook.MAPIFolder folderInbox = null;
            Outlook.MAPIFolder folderSentMail = null;
            Outlook.NameSpace ns = null;
            try
            {
                ns = Application.GetNamespace("MAPI");
                folderInbox = ns.GetDefaultFolder(Outlook.OlDefaultFolders.olFolderInbox);
                folderSentMail = ns.GetDefaultFolder(Outlook.OlDefaultFolders.olFolderSentMail);
                scope = "\'" + folderInbox.FolderPath + "\',\'" +
                                                           folderSentMail.FolderPath + "\'";
                advancedSearch = Application.AdvancedSearch(
                                                    scope, filter, true, advancedSearchTag);
                Application.AdvancedSearchComplete += Application_AdvancedSearchComplete;
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message, "An eexception is thrown");
            }
            return advancedSearch;
            finally
            {
                if (advancedSearch != null) Marshal.ReleaseComObject(advancedSearch);
                if (folderSentMail != null) Marshal.ReleaseComObject(folderSentMail);
                if (folderInbox != null) Marshal.ReleaseComObject(folderInbox);
                if (ns != null) Marshal.ReleaseComObject(ns);
            }
            
        }
        //Handle AdvancedSearchComplete event
        void Application_AdvancedSearchComplete(Outlook.Search SearchObject)
        {
            Outlook.Results advancedSearchResults = null;
            Outlook.MailItem resultItem = null;
            System.Text.StringBuilder strBuilder = null;
            try
            {
                if (SearchObject.Tag == advancedSearchTag)
                {
                    advancedSearchResults = SearchObject.Results;
                    System.Diagnostics.Debug.WriteLine("Count: " + advancedSearchResults.Count);
                    if (advancedSearchResults.Count > 0)
                    {
                        strBuilder = new System.Text.StringBuilder();
                        strBuilder.AppendLine("Number of items found: " +
                                                advancedSearchResults.Count.ToString());
                        foreach (MailItem item in advancedSearchResults)
                        {
                            System.Diagnostics.Debug.WriteLine(item.Subject);
                        }
                        for (int i = 1; i <= advancedSearchResults.Count; i++)
                        {
                            resultItem = advancedSearchResults[i] as Outlook.MailItem;
                            if (resultItem != null)
                            {
                                strBuilder.Append("#" + i.ToString());
                                strBuilder.Append(" Subject: " + resultItem.Subject);
                                strBuilder.Append(" \t To: " + resultItem.To);
                                strBuilder.AppendLine(" \t Date: " +
                                                        resultItem.SentOn.ToString());
                                Marshal.ReleaseComObject(resultItem);
                            }
                        }
                        if (strBuilder.Length > 0)
                            System.Diagnostics.Debug.WriteLine(strBuilder.ToString());
                        else
                            System.Diagnostics.Debug.WriteLine(
                                                        "There are no Mail items found.");
                        
                    }
                    else
                    {
                        System.Diagnostics.Debug.WriteLine("There are no items found.");
                    }
                }
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message, "An exception is occured");
            }
            finally
            {
                if (resultItem != null) Marshal.ReleaseComObject(resultItem);
                if (advancedSearchResults != null)
                    Marshal.ReleaseComObject(advancedSearchResults);
            }
        }
      private void btnOutlookSrch_Click(object sender, EventArgs e)
        {
           Outlook.Application OLook = new Outlook.Application();
           RunAdvancedSearch(OLook, "Hello?");
        }
