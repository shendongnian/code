    try
    {
        WebResponse response = request.GetResponse();
    }
    catch (FileNotFoundException fex)
    {
        Console.WriteLine("Unable to find file " + fex.FileName);
    }
    catch (Exception ex)
    {
        Console.WriteLine("Some other exception.");
    }
