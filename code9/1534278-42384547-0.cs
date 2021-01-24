    public Tuple<List<string>,List<string>> GetDataFromFile()
    {
        XDocument doc = XDocument.Load("NotificationTasks.xml");
        var dates = doc.Descendants("Date");
        var hours = doc.Descendants("Time");
        var hoursCollection = new List<string>();
        var dateCollection = new List<string>();
    
        foreach (var date in dates)
        {
            dateCollection.Add(date.Value);
        }
    
        foreach (var hour in hours)
        {
            hoursCollection.Add(hour.Value);
        }
    
        return Tuple.Create(hoursCollection,dateCollection);
    }
    
    
      private void btnStart_Click(object sender, EventArgs e)
        {
    
            //here I must use the two collections from GetDataFromFile()
            Tuple<List<String>,List<String>> t = GetDataFromFile();
            List<String> hoursCollection = t.Item1;
            List<String> dateCollection = t.Item2;
    
            foreach (var dates in hoursCollection)
            {
                if (dates == DateTime.Now.Date)
                {
                    foreach (var hours in hoursCollection)
                    {
                        StartNotificating(new TimeSpan(hours));
                    }
                }
            }
        }
