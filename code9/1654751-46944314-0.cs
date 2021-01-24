    class Program
        {
            static void Main(string[] args)
            {
    
                List<Customers> customers = new List<Customers>();
                customers.Add(new Customers() { ID = 1, Name = "Bill" });
                customers.Add(new Customers() { ID = 2, Name = "John" });
    
                List<Purchases> purchases = new List<Purchases>();
                purchases.Add(new Purchases() { ID = 1, CustomerID = 1, CompletedTransaction = false });
                purchases.Add(new Purchases() { ID = 2, CustomerID = 2, CompletedTransaction = true });
                purchases.Add(new Purchases() { ID = 3, CustomerID = 1, CompletedTransaction = true });
                purchases.Add(new Purchases() { ID = 4, CustomerID = 1, CompletedTransaction = true });
    
                IEnumerable<JoinResult> results = from c in customers
                                           join p in purchases
                                           on c.ID equals p.CustomerID
                                           group new { c, p } by new {p.CustomerID, c.Name} into r
                                           select new JoinResult
                                           {
                                               CustomerID = r.Key.CustomerID,
                                               CustomerName = r.Key.Name,
                                               TotalPurchases = r.Count(),
                                               TotalCompleteTransaction = r.Where(s=> s.p.CompletedTransaction).Count()
                                           };
    
                foreach(JoinResult r in results)
                {
                    Console.WriteLine($"CustomerID : {r.CustomerID} | Name : {r.CustomerName} | TotalPurchases : {r.TotalPurchases} | TotalCompleteTransaction : {r.TotalCompleteTransaction}");
                }
              
                Console.ReadKey();
            }
        }
    
        class Customers
        {
            public int ID { get; set; }
            public string Name { get; set; }
        }
    
        class Purchases
        {
            public int ID { get; set; }
            public int CustomerID { get; set; }
            public bool CompletedTransaction { get; set; }
        }
    
        class JoinResult
        {
            public int CustomerID { get; set; }
            public string CustomerName { get; set; }
            public int TotalPurchases { get; set; }
            public int TotalCompleteTransaction { get; set; }
        }
