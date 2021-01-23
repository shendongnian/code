    public class Program
    {
        public static void Main(string[] args)
        {
             List<TimeValue> ttcaList = new List<TimeValue>();
            Random s = new Random();
            DateTimeOffset dto = DateTimeOffset.Now;  
            for (int i = 0; i < 6; i++)
            {
                ttcaList.Add(new TimeValue(dto.AddMinutes(i*5), s.Next(0, 20)));
            }
            for (int i = 0; i < 5; i++)
            {
                ttcaList.Add(new TimeValue(dto.AddMinutes(10*5).AddMinutes(i*5), s.Next(0, 20)));
            }
            foreach (var item in ttcaList)
            {
                Console.WriteLine(item.Time+"   value "+ item.Value);
            }
            
            List<List<TimeValue>> grouped = new List<List<TimeValue>>();
            
            var interval = 5;
            DateTimeOffset lastTime = new DateTimeOffset();
            
            foreach (var item in ttcaList)
            {
                
                if (grouped.Count == 0) 
                {
                    grouped.Add(new List<TimeValue>() {item});
                    lastTime = item.Time;
                }
                else 
                {
                    if ((item.Time - lastTime).TotalMinutes <= interval)
                        grouped.Last().Add(item);
                    else 
                        grouped.Add(new List<TimeValue>() {item});
                    
                    lastTime = item.Time;
                }
            }
 
            Console.WriteLine("\n\n grouped data");
            foreach (var skup in grouped)
            {
                Console.WriteLine("\t\t group");
            foreach (var item in skup)
            {
                
                Console.WriteLine(item.Time+"   value "+ item.Value);
             }
            }
        }
