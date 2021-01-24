    static void Main(string[] args)
    {
        var list = new List<MyObj>
        {
            new MyObj { TransType = "Credit", PaymentMethod = 1, Amount = 1000 },
            new MyObj { TransType = "Debit", PaymentMethod = 2, Amount = 2000 },
            new MyObj { TransType = "Debit", PaymentMethod = 1, Amount = 4000 },
            new MyObj { TransType = "Credit", PaymentMethod = 3, Amount = 3000 }
        };
    
        var filtered = from o in list
                       where o.TransType == "Credit"
                       select new
                       {
                          o.TransType,
                          o.PaymentMethod,
                          o.Amount,
                          Credit = "<VALUE>",
                          Debit = "<VALUE>"
                       };
    }
    class MyObj
    {
        public string TransType { get; set; }
        public int PaymentMethod { get; set; }
        public int Amount { get; set; }
    }
