     int num;
     string prvnicislo =  Console.ReadLine(); 
     while (!int.TryParse(prvnicislo, out num))
     {
         Console.WriteLine("'{0}' is not int, try it again:", prvnicislo);
         prvnicislo = Console.ReadLine();
     }
     Console.WriteLine("Hi");
