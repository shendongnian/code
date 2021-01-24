    class Program
    {
        static void Main(string[] args)
        {
            Atm[] atm = new Atm[3];
            atm[0] = new Atm(50);
            atm[1] = new Atm(100000);
            atm[2] = new Atm(25);
            int totalBalance=0;
           for( int i=0;i<atm.Length;i++)
            {
                totalBalance += atm[i].Balance;
            }
            Console.WriteLine("TotalBalance is "+totalBalance.ToString("c"));
            Console.ReadKey();
        }
    }
    class Atm
    {
        public int Balance { get; private set; }
        public Atm(int balance)
        {
             Balance=balance;
        }
    }
