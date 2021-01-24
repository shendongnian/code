    class doc{
    
        public int Pay{get;set;}
        public int Receive{get;set;}
    }
    
    public class Program
    {
        public static void Main(string[] args)
        {
            List<doc> lst = new List<doc>();
            lst.Add(new doc(){Receive=2,Pay=0});
            lst.Add(new doc(){Receive=0,Pay=4});
            lst.Add(new doc(){Receive=3,Pay=0});
            lst.Add(new doc(){Receive=4,Pay=0});
            
            int remain = 1; // initialRecieve=1
            var result = (from line in lst
                            select new {
                            Receive = line.Receive,
                            Pay = line.Pay,
                            Remain = (remain = remain + line.Receive - line.Pay)
                          }).ToList();
            foreach(var item in result){
            Console.WriteLine(item);
            }
        }
    }
