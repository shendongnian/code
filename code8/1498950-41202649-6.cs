        static void Main(string[] args)
        {
            List<ILoanBase> loans=new List<ILoanBase>();
            //populate list
            var abc=new Loan() { Issuer="ABC", Rate=0.22m };
            abc.AddDebt(1002, 5400m);
            loans.Add(abc);
    
            //iterate list
            foreach (var loan in loans)
            {
                Console.WriteLine(loan.Issuer);
                foreach (var debt in loan.GetDebts())
                {
                    Console.WriteLine(debt.Amount.ToString("C"));
                }
            }
            // ABC
            // $5,400.00
        }
