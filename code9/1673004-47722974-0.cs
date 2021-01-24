    public class RateInfo
    {
      public x Rate { get; set; }
      public x Class { get; set; }
    }
    var data = db.Rates.SqlQuery<RateInfo>("select Rate, Class from Rates");
