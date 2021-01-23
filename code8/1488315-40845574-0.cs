    public class Letter
    {
        public int Id { get; set; }
        public int SenderId { get; set; }
    }
    public class Sender
    {
        public int Id { get; set; }
        public string Country { get; set; }
    }
    public class Receiver
    {
        public int Id { get; set; }
        public int LetterId { get; set; }
        public string Country { get; set; }
    }
    class StackOverflow_SQLtoLinq
    {
        static void Main(string[] args)
        {
            List<Letter> lstLetters = new List<Letter>() { 
            new Letter(){Id=1,SenderId=1},
            new Letter(){Id=2,SenderId=2},
            new Letter(){Id=3,SenderId=3}
            };
            List<Sender> lstSenders = new List<Sender>() {
            new Sender(){Id=1,Country="IND"}, 
            new Sender(){Id=2,Country="US"},  
            new Sender(){Id=3,Country="NZ"}
            };
            List<Receiver> lstReceivers = new List<Receiver>() { 
            new Receiver(){Id=1,LetterId=1,Country="IND"},
            new Receiver(){Id=2,LetterId=11,Country="US"},
            new Receiver(){Id=3,LetterId=1,Country="NZ"},
            };
            var data = (from receiver in lstReceivers
                       join letter in lstLetters on receiver.LetterId equals letter.Id 
                       join sender in lstSenders on letter.SenderId equals sender.Id
                        group sender by new { id = sender.Id, country = sender.Country } into finalData
                       select new
                       {
                           country = finalData.Key.country,
                           Count = finalData.Distinct().Count()
                       }).ToList();
        }
    }
