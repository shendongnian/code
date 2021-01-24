    internal class Ticket
    {
        public string TicketType { get; set; }
        public int Quantity { get; set; }
        public decimal Amount { get; set; }
    }
    internal class Program
    {
        private static void Main(string[] args)
        {
            var list = new List<Ticket>();
            list.Add(new Ticket() { TicketType = "Standard", Quantity = 1, Amount = 8.5m });
            list.Add(new Ticket() { TicketType = "Standard", Quantity = 1, Amount = 8.5m });
            list.Add(new Ticket() { TicketType = "Student", Quantity = 1, Amount = 6.5m });
            list.Add(new Ticket() { TicketType = "Student", Quantity = 1, Amount = 6.5m });
            list.Add(new Ticket() { TicketType = "Senior", Quantity = 1, Amount = 4m });
            foreach (var item in list)
            {
                System.Console.WriteLine($"TicketType: {item.TicketType}, Quantity: {item.Quantity}, Amount: {item.Amount}");
            }
            System.Console.WriteLine("------------------------------------------");
            list = list.GroupBy(x => x.TicketType).Select(x => new Ticket()
            {
                TicketType = x.First().TicketType,
                Quantity = x.Sum(y => y.Quantity),
                Amount = x.Sum(y => y.Amount)
            }).ToList();
            foreach (var item in list)
            {
                System.Console.WriteLine($"TicketType: {item.TicketType}, Quantity: {item.Quantity}, Amount: {item.Amount}");
            }
            System.Console.Read();
        }
     }
