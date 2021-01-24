    using(MyContext ctx = new Context())
    {
        object ca = ctx.CheckingAccount.Find(pKey);
        object sa = ctx.SavingAccount.Find(pKey);
    
        if(ca is CheckingAccount)
        {
            Console.WriteLine("It's a CheckingAccount!");
        }
        else if(sa is SavingAccount)
        {
            Console.WriteLine("It's a SavingAccount!");
        }
    }
