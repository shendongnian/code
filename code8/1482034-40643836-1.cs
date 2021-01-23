        foreach(var prop in checkInVar.GetType().GetProperties())
        { 
            Console.WriteLine("{0} = {1}", prop.Name, prop.GetValue(checkInVar, null)); 
        }
    }
