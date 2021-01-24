    public void SummaryTable(List<Person> list)
    {
        foreach (Person p in list)
        {
            Console.Write("{0}", p.firstName);
            Console.Write("{0}", p.lastName);
            Console.Write("{0}", p.weeks);
            Console.Write("{0}", p.discount);
            Console.Write("{0}", p.charge);
        }
    }
