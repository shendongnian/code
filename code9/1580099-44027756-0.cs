    var convertedRawNepaliDate = new DateConverter().EngToNep(1993, 9, 30);
    //English To Nepali date
    //Separete properties for Year Month and Day.
    var convertedNepaliDate = DateTime.Parse(convertedRawNepaliDate.ConvertedDate.Year.ToString() + "-" + convertedRawNepaliDate.ConvertedDate.Month.ToString() + "-" + convertedRawNepaliDate.ConvertedDate.Day.ToString());
    
    var eqNepaliDay = convertedRawNepaliDate.ConvertedDayOfWeek; //Gives Nepali Day
    
    //Nepali to english
    var convertedRawEnglishDate = new DateConverter().NepToEng(2050, 06, 14);
    
    var convertedNepaliDate = DateTime.Parse(convertedRawEnglishDate.ConvertedDate.Year.ToString() + "-" + convertedRawEnglishDate.ConvertedDate.Month.ToString() + "-" + convertedRawEnglishDate.ConvertedDate.Day.ToString());
    
    var eqEnglishDay = convertedRawEnglishDate.ConvertedDayOfWeek; //Gives English Day
