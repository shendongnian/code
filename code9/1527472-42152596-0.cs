    enum DaysInMonth
            {
                Jan = 31, Feb = 28, Mar = 31, Apr = 30, May = 31, Jun = 30,
                Jul = 31, Aug = 31, Sep = 30, Oct = 31, Nov = 30, Dec = 31
            };
    static void Main(string[] args)
            {
                DaysInMonth dm = DaysInMonth.Dec;
                Console.WriteLine("Number of days in {0} is {1} : ", dm, (int)dm);
                Console.ReadKey();
            }
