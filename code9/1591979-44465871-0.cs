    class Account
    {
        int AccountNumber { get; set; }
        string Name { get; set; }
        float Balance { get; set; }
        //added this line
        private ArrayList list {get;set;}
        public void CreateAccount()
        {
            int AccountNumberInput;
            string NameInput;
            float BalanceInput;
            //notice this
            list = new ArrayList();
            Console.WriteLine("put id");
            AccountNumberInput = int.Parse(Console.ReadLine());
            Console.WriteLine("type name");
            NameInput =Console.ReadLine();
            Console.WriteLine("type balance");
            BalanceInput = float.Parse(Console.ReadLine());
            list.Add(AccountNumberInput);
            list.Add(NameInput);
            list.Add(BalanceInput);
        }
        public void ReadList()
        {
            //removed ArrayList list = new ArrayList();
            foreach (string c in list)
            {
                Console.WriteLine(c);
            }
        }
    }
