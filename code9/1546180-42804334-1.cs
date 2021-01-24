    [HttpPost]
    [AcceptVerbs(HttpVerbs.Post)]
    public static ActionResult SearchAd(string LoginName = "")
    {
        string x = "Not Found";
        DirectoryEntry directoryEntry = new DirectoryEntry("LDAP://lbcone");
        DirectorySearcher directorySearcher = new DirectorySearcher(directoryEntry);
        directorySearcher.Filter = string.Format("(&(SAMAccountName={0}))", LoginName);
        var user = directorySearcher.FindOne();
        if (user != null)
        {
            x = "Found";
        }
        return Json(x, JsonRequestBehavior.DenyGet);
    }
