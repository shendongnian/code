    void ITestModule.Run()
    {
    // Create PopupWatcher
    PopupWatcher myPopupWatcher = new PopupWatcher();
    // Add a Watch using a RanoreXPath and triggering the Method CloseUpdateCheckDialog
    myPopupWatcher.Watch("/form[@controlname='UpdateCheckForm']/button[@controlname='m_btnClose']", CloseUpdateCheckDialog);
    // Add a Watch using the info object of a button and triggering the Method CloseUpdateCheckDialog
    // myPopupWatcher.Watch(repo.UpdateCheckDialog.btCloseInfo, CloseUpdateCheckDialog);
    // Add a Watch using the info object of the dialog and the info object of the button to click
    // myPopupWatcher.WatchAndClick(repo.UpdateCheckDialog.SelfInfo, repo.UpdateCheckDialog.btCloseInfo);
    // Add a Watch using a repository folder object and the info object of the button to click
    // myPopupWatcher.WatchAndClick(repo.UpdateCheckDialog, repo.UpdateCheckDialog.btCloseInfo);
    // Start PopupWatcher
    myPopupWatcher.Start();
    }
    public static void CloseUpdateCheckDialog(Ranorex.Core.Repository.RepoItemInfo myInfo, Ranorex.Core.Element myElement)
    {
    myElement.As<ranorex.button>().Click();
    }
    public static void CloseUpdateCheckDialog(Ranorex.Core.RxPath myPath, Ranorex.Core.Element myElement)
    {
    myElement.As<ranorex.button>().Click();
    }
