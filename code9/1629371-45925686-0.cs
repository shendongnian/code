    string path = HttpRuntime.AppDomainAppPath + "\\Content\\Images\\";
    // Or string path = Server.MapPath("~/Content/Images/");
    var gembymonth = new List<GemStoneByMonth>
    {
        new GemStoneByMonth
        {
            EnglishZodiac = "Cancer",
            SanskritZodiac = "Karka",
            GemEng = "Yellow Saphire",
            GemImage = path + "Yellow Saphire.png"
        }
    };
