    '    class Program
    {
        static void Main(string[] args)
        {
            List<Billing> Billings = new List<Billing>()
            {
                new Billing()
                {
                    AccountID = 1234, DateOfBill = new DateTime(2017,07,12), Group = "A"
                },
                new Billing()
                {
                    AccountID = 1234, DateOfBill = new DateTime(2017,07,16), Group = "B"
                },
                new Billing()
                {
                    AccountID = 1234, DateOfBill = new DateTime(2017,07,31), Group = "C"
                },
                new Billing()
                {
                    AccountID = 1234, DateOfBill = new DateTime(2017,07,31), Group = "A"
                },
                new Billing()
                {
                    AccountID = 1234, DateOfBill = new DateTime(2017,07,31), Group = "B"
                }               
            };
            var LatestAccount = from n in Billings
                                where (n.Group == "A" || n.Group == "B" || n.Group == "C")
                                group n by new { n.AccountID, n.Group } into g
                                where g.Any( x => x.DateOfBill == g.Max(m => m.DateOfBill))
                                select new { AccountId = g.Key.AccountID, Group = g.Key.Group, DateOfBill = g.Max(t => t.DateOfBill) };
            foreach (var item in LatestAccount)
            {
                Console.WriteLine("AccountID: " + item.AccountId + "  Date of Bill: "  + item.DateOfBill + "  Group: "+ item.Group);
            }
            Console.ReadLine();
        }
    }
    class  Billing
    {
        public int AccountID { get; set; }
        public string Group { get; set; }
        public DateTime DateOfBill { get; set; }
    }'
