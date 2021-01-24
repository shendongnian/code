    try
    {
        Console.WriteLine("Enter 1- id  2- Seclevel 3- salary 4- hired day 5- hired month 6- hired month 7- hired year 8-gender");
        employee[i].id = Int32.Parse(Console.ReadLine());
        employee[i].hired.hday = Int32.Parse(Console.ReadLine());
        employee[i].hired.hmonth = Int32.Parse(Console.ReadLine());
        employee[i].hired.hyear = Int32.Parse(Console.ReadLine());
        employee[i].salary = double.Parse(Console.ReadLine());
        employee[i].secl = (securitylevel)Enum.Parse(typeof(securitylevel), Console.ReadLine());
        employee[i].gen = (gender)Enum.Parse(typeof(gender), Console.ReadLine());
    }
    catch (Exception ex)
    {
        throw new CustomExc();
    }
