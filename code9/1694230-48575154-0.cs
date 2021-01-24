    List<Empployee> lst = new List<Empployee>();
    
                lst.GroupBy(g => g.ID).ToList().ForEach(g =>
                {
                    Console.WriteLine($"Key:{g.Key} and Value:{g.Max(m => m.Age)}");
                });
    public class Empployee
            {
               public int ID { get; set; }
               public int Age { get; set; }
            }
