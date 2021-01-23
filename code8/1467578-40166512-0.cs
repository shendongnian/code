      set Session = CreateObject("Redemption.RDOSession")
      Session.MAPIOBJECT = Application.Session.MAPIOBJECT
      set item = Session.GetMessageFromID(Application.ActiveExplorer.Selection(1).EntryID)
      for each attach in item.Attachments
        MsgBox attach.AsText
      next
