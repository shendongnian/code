     MAPI_NO_CACHE = &H200
     MAPI_BEST_ACCESS = &H10
     set OutlookFolder = Application.ActiveExplorer.CurrentFolder
     set Session = CreateObject("Redemption.RDOSession")
     Session.MAPIOBJECT = Application.Session.MAPIOBJECT
     set OnlineFolder = Session.GetFolderFromID(OutlookFolder.EntryID, OutlookFolder.StoreID, MAPI_NO_CACHE + MAPI_BEST_ACCESS)
     MsgBox OnlineFolder.Items.Count
