    //perform PwrQuery and retrieve lastbootuptime
    IEnumerable<CimInstance> Results = Session.QueryInstances(Namespace, "WQL", PwrQuery);
    DateTime LastBootUpTime = Convert.ToDateTime(Results.First().CimInstanceProperties["LastBootUpTime"].Value);
    //add PwrOnDuration and LastRestart to Record
    Record.LastRestart = LastBootUpTime.ToString();
    Record.PwrOnDuration = (DateTime.Now - LastBootUpTime).ToString(@"dd\/hh\:mm\:ss");
