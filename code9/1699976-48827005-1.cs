      List<Journey> list = new List<Journey>();
    
                list.Add(new Journey() {From="Delhi",To="Mumbai",Gender=Gender.MALE });
                list.Add(new Journey() { From = "Delhi", To = "Mumbai", Gender = Gender.MALE });
                list.Add(new Journey() { From = "Delhi", To = "Mumbai", Gender = Gender.FEMALE });
                list.Add(new Journey() { From = "Delhi", To = "Mumbai", Gender = Gender.CHILD });
                list.Add(new Journey() { From = "Delhi", To = "Mumbai", Gender = Gender.MALE });
                list.Add(new Journey() { From = "Delhi", To = "Mumbai", Gender = Gender.MALE });
                list.Add(new Journey() { From = "Mumbai", To = "Mohili", Gender = Gender.FEMALE });
                list.Add(new Journey() { From = "Mumbai", To = "Mohili", Gender = Gender.CHILD });
                list.Add(new Journey() { From = "Mumbai", To = "Mohili", Gender = Gender.CHILD });
    
                var grp = list.GroupBy(s => new { s.From, s.To }).ToDictionary(d => d.Key, d => d.Select(i=>new JourneyCalc { From=i.From,To=i.To,Gender=i.Gender}).ToList());
    
                foreach (var item in grp)
                {
                    var str = from val in item.Value group val by val.Gender into itmgrp select new JourneyCalc { Gender = itmgrp.Key, JourneyCount = itmgrp.Count() };
                    foreach (JourneyCalc jc in str)
                    {
                        Console.WriteLine(value: $"{item.Value[0].From} - {item.Value[0].To} => {jc.Gender} - {jc.JourneyCount}");
                    }
                } 
    
    
    
        public class JourneyCalc
        {
            public string From { get; set; }
            public string To { get; set; }
            public Gender Gender { get; set; }
            public int JourneyCount { get; set; }
        }
        public enum Gender
        {        
            MALE,
            FEMALE,
            CHILD
        }
        public class Journey
        {
            public string From { get; set; }
            public string To { get; set; }
            public Gender Gender { get; set; }
    
        }
    
    Output:
    
    Delhi - Mumbai => MALE - 4
    Delhi - Mumbai => FEMALE - 1
    Delhi - Mumbai => CHILD - 1
    Mumbai - Mohili => FEMALE - 1
    Mumbai - Mohili => CHILD - 2
