    var list = new List<Holiday>()
    {
         new Holiday(new DateTime(2016,1,1),"NEW YEAR 2016"),
         new Holiday(new DateTime(2016,3,27),"EASTER MONDAY 2016", new DateTime(2016,3,28)),
         new Holiday(new DateTime(2016,12,25),"CHRISTMAS DAY 2016", new DateTime(2016,12,26)),
         new Holiday(new DateTime(2017,1,1),"NEW YEAR 2017", new DateTime(2017,1,2)),
         new Holiday(new DateTime(2017,4,17),"EASTER MONDAY 2017"),
         new Holiday(new DateTime(2017,12,25),"CHRISTMAS DAY 2017"),
         new Holiday(new DateTime(2018,1,1),"NEW YEAR 2018"),
         new Holiday(new DateTime(2018,1,1),"DUPLICATE 1"), //example of a duplicate
         new Holiday(new DateTime(2018,1,2),"DUPLICATE 2", new DateTime(2016,1,1)), //example of a duplicate
         new Holiday(new DateTime(2018,1,3),"DUPLICATE 3", new DateTime(2017,1,2)), //example of a duplicate
         new Holiday(new DateTime(2018,1,4),"DUPLICATE 4", new DateTime(2018,1,4)), //example of a duplicate
    };
