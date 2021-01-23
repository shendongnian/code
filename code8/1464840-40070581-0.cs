    static void Main(string[] args)
    {
        Person me = new Prasanth("MyName");
        me.DisplayName();
        // vvvvvv   here you lose the reference to the old object
        me = new AnotherPerson("AnotherName"); ;
        me.DisplayName();
        Console.ReadLine();
    }
