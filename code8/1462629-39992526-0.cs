    var success = false;
    while (success == false)
    {
        Console.WriteLine("Enter The File Location");
        string userValue = Console.ReadLine();
        try
        {
            string content = File.ReadAllText(userValue);
            Console.WriteLine(content);            
            success = true;
        }
        catch (FileNotFoundException ex)
        {
            Console.WriteLine("There was a Problem");
            Console.WriteLine(ex.Message);
        }  
        catch (DirectoryNotFoundException ex)
        {
            Console.WriteLine("There was a Problem");
            Console.WriteLine("Could not find the Directory");
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }    
    }
