    Try
    {
        String result = GetKey();
        if (result == null)
        {
            Console.WriteLine("null");
        }
        else
        {
            Console.WriteLine(result);
        }
    }
    catch
    {
        Console.WriteLine("Reading key failed");
    }
        Console.ReadKey();
