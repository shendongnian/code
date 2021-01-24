    private void ThisAddIn_Startup(object sender, System.EventArgs e)
            {
                application = this.Application;
                Outlook._NameSpace mapiNameSpace = application.GetNamespace("MAPI");
                memofolder = mapiNameSpace.GetDefaultFolder(Microsoft.Office.Interop.Outlook.OlDefaultFolders.olFolderNotes);
