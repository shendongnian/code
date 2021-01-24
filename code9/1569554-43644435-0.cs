    public class Hour
    {
       // ...
       [NotMapped]
       public TimeSpan TotalHrs
       {
           get
           {
               return this.StartDateTime - this.EndDatetime;
           }
       }
       // ...
    }
