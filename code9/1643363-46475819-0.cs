    public ActionResult MyAction(string CID, string SD, string ED , short? DCost)
    {
       DateTime date1 = DateTime.ParseExact(SD, "ddd MMM d yyyy HH:mm:ss GMTzzzzz", CultureInfo.InvariantCulture);
       DateTime date2 = DateTime.ParseExact(ED, "ddd MMM d yyyy HH:mm:ss GMTzzzzz", CultureInfo.InvariantCulture);
    }
