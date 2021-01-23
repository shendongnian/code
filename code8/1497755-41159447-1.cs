    private Outlook.Application ouApplication;
    if(!AlreadyAdded())
    {
       ouApplication = new Outlook.Application();
       Outlook.Folder newFolder = ouApplication.GetNamespace("MAPI").OpenSharedFolder("webcalURL") as Outlook.Folder;
    }
    bool AlreadyAdded()
    {
       return ouApplication!=null;
    }
