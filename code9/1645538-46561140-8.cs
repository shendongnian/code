     public class Program
        {
            public static void Main(string[] args) {
                List<Calculation> lstCalc = new List<Calculation>();
                lstCalc.Add(new Calculation() {SampleSetID=1, Value=10 });
                lstCalc.Add(new Calculation() { SampleSetID = 1, Value = 10 });
                lstCalc.Add(new Calculation() { SampleSetID = 2, Value = 20 });
                lstCalc.Add(new Calculation() { SampleSetID = 3, Value = 30 });
                lstCalc.Add(new Calculation() { SampleSetID = 4, Value = 40 });
                lstCalc.Add(new Calculation() { SampleSetID = 5, Value = 50 });
                lstCalc.Add(new Calculation() { SampleSetID = 6, Value = 60 });
                lstCalc.Add(new Calculation() { SampleSetID = 7, Value = 70 });
                lstCalc.Add(new Calculation() { SampleSetID = 8, Value = 80 });
                lstCalc.Add(new Calculation() { SampleSetID = 9, Value = 90 });
    
                List<SampleSet> lstSampleSet = new List<SampleSet>();
                lstSampleSet.Add(new SampleSet() {Department = "Location A", ID=1, SampleDrawn=DateTime.Now.AddMonths(-5)});
                lstSampleSet.Add(new SampleSet() { Department = "Location A", ID = 2, SampleDrawn = DateTime.Now.AddMonths(-4) });
                lstSampleSet.Add(new SampleSet() { Department = "Location A", ID = 3, SampleDrawn = DateTime.Now.AddMonths(-3) });
                lstSampleSet.Add(new SampleSet() { Department = "Location A", ID = 4, SampleDrawn = DateTime.Now.AddMonths(-2) });
                lstSampleSet.Add(new SampleSet() { Department = "Location A", ID = 5, SampleDrawn = DateTime.Now.AddMonths(-2) });
                lstSampleSet.Add(new SampleSet() { Department = "Location A", ID = 6, SampleDrawn = DateTime.Now.AddMonths(-2) });
                lstSampleSet.Add(new SampleSet() { Department = "Location A", ID = 7, SampleDrawn = DateTime.Now.AddMonths(-1) });
    
                var query = (from a in lstCalc
                            join b in lstSampleSet
                            on a.SampleSetID equals b.ID where b.SampleDrawn >= DateTime.Now.AddMonths(-8)
                             && b.Department == "Location A"
                            select new { All = 0, Range = Utilities.RangeProvider(a.Value) }).ToList();
    
                Console.WriteLine(query.Count);
                Console.ReadLine();
    
            }
    
          
        }
    
            public class Utilities
            {
                public static string RangeProvider(int value)
                {
                    if (value > 0 && value <= 25)
                    { return "Low"; }
                    if (value > 25 && value <= 75)
                    { return "Medium"; }
                    if (value > 75 && value <= 90)
                    { return "High"; }
                    else
                    { return "Very High"; }
                }
    
            }
        public class Result {
          public int All { get; set; }
          public string Range { get; set; }
       }
    
        public class Calculation
        {
            public int SampleSetID { get; set; }
            public int Value { get; set; }
    
        }
    
        public class SampleSet
        {
            public int ID { get; set; }
            public DateTime SampleDrawn { get; set; }
    
            public string Department { get; set; }
    
        }
