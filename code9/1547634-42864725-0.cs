    //split str in to strDate and strTime by using space
        var strDate = "20170317"; //Date part
        var strTime ="630";       //Time part
        if(strTime.Length ==3)   //check lenght of time part
        {
             strTime = "0" + strTime;  //Add extra zero
        }
        var formatedTime = "yyyyMMdd HHmm";
        DateTime etaDate;
        if (!DateTime.TryParseExact(strDate + strTime,formatedTime, CultureInfo.InvariantCulture, DateTimeStyles.None, out etaDate))  //formatedTime, CultureInfo.InvariantCulture, DateTimeStyles.None
        {
            Console.WriteLine("Date conversion failed " +  etaDate);
        }
    
        Console.WriteLine("Date conversion passed "+etaDate);
