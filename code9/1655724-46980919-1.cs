    public ActionResult _Alerts(UserADInfoModel model, List<string> groups)
    {
        DataRowCollection drColl = Core.GetAlerts(model);
        ViewBag.Alerts = drColl;
        var path = @"Exchange Migration data 10-25-17.csv";
        using (TextFieldParser csvParser = new TextFieldParser(path))
        {
            // ...
            while (!csvParser.EndOfData)
            {
                string[] fields = csvParser.ReadFields();
                model.pin = fields[0];
                model.tDate = fields[2];
                model.stat = fields[6];
            }
        }
        return PartialView(model);
    }
