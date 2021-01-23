        Console.WriteLine("What is your name?");
        var value = Console.ReadLine();
        int intVal;
        if(Int32.TryParse(value, out intVal))
        {
            Console.WriteLine(intVal);
        }
        
