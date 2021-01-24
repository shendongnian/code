    public ActionResult _Alerts(UserADInfoModel model, List<string> groups)
    {
        DataRowCollection drColl = Core.GetAlerts(model);
        ViewBag.Alerts = drColl;
        string pin = null;
        string tDate = null;
        string stat = null;
        var path = @"Exchange Migration data 10-25-17.csv";
        using (TextFieldParser csvParser = new TextFieldParser(path))
        {
            // ...
            while (!csvParser.EndOfData)
            {
                string[] fields = csvParser.ReadFields();
                pin = fields[0];
                tDate = fields[2];
                stat = fields[6];
            }
        }
        return PartialView(model, pin, tDate, stat);
    } 
