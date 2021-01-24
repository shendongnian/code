     string datestr = "26/12/2017 12:00:00 am";
        DateTime test = DateTime.Now;
       if( DateTime.TryParseExact(datestr, "dd/MM/yyyy hh:mm:ss tt", null,
                               DateTimeStyles.None, out test))
        {
             //insert in db or proceed with input
        }
        else
        {
          //log and provide error message 
         }
