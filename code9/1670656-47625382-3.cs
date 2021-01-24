    public class Shoulders
    {
        public int Id { get; set; }
    
        public DateTime WorkoutDate { get; set; }
        [Display(Name ="Military Press")]
        public double MilitaryPress { get; set; }
        [Display(Name = "Sides Launch")]
        public double SidesLaunch { get; set; }
        [Display(Name = "Front Launch")]
         public double FrontLaunch { get; set; }
         // if you want it set automatically add this constructor
        public Shoulders()
        {
            WorkoutDate = DateTime.Now();
        }
    }
