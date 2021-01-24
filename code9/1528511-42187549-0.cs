    try
    {
        sda.Fill(dt);
    }
    catch (SQLException ex)
    {
        Console.WriteLine(ex.ToString());
    }
