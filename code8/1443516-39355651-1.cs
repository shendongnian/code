    public void foo()
    {
        try
        {
            if (String.IsNullOrEmpty(command.Address.PrimitiveAddress.City)){} // Ect
        }
        catch (CommandInvalidException e)
        {
            Console.WriteLine("Command invalid due to " + e.message);
            // Or any other way you want to deal with the missing data
        }
    }
