        db.CreateTableIfNotExists<Message>();                    
        Message notex = new Message();
        notex.Content = msg.Content;
        notex.Datestamp = msg.Datestamp;
        notex.Facility = msg.Facility;
        notex.Hostname = msg.Hostname;
        notex.LocalDate = msg.LocalDate;
        notex.RemoteIP = msg.RemoteIP;
        notex.Severity = msg.Severity;
        db.Insert(notex);
    }
