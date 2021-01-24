    PrayUpPrayers prayUpPrayers1 = new PrayUpPrayers
    {
        prayer = "Please pray for my dog Rusty. He has cancer",
        prayerid = "2",
        prayerCategory = "General",
        prayerDate = "2017-06-10T21:24:16.1",
        handle = "GuruJee",
        country = "USA"
    };
    PrayUpPrayers prayUpPrayers2 = new PrayUpPrayers
    {
        prayer = "Help Me I need a appendectomy STAT",
        prayerid = "1",
        prayerCategory = "Sports",
        prayerDate = "2017-04-10T20:30:39.77",
        handle = "GuruJee",
        country = "USA"
    };
    ThePrayer thePrayer = new ThePrayer
    {
        prayers = new List<PrayUpPrayers>
        {
            prayUpPrayers1, prayUpPrayers2
        }
    };
