    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Approve (int id, History history)
    {
        try {
        // The logic processing will be done inside ApproveRecord and match up against Analytics or Manager roles.
        _historyRepository.ApproveRecord(history, Roles.GetRolesForUser(yourUser)); 
       } 
       catch(Exception ex) {
           // Could make your own Exceptions here for the user not being authorised for the action.
       }
    }
