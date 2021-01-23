    string sessionVariable = Convert.ToString(Session["lastcallid"]); 
    string path = Path.Combine(MapPath(@"~\TicketUploads\"), sessionVariable);
    if (!Directory.Exists(path))
    {
        Directory.CreateDirectory(path);
    }
