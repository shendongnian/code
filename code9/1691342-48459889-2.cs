    try
    {
        int.Parse("dd");
    }
    catch (Exception e)
    {
        var s = new StackTrace(e); // Gets the stack trace where the exception was thrown not where it was caught.
        var frame = s.GetFrame(0);
        var sourceMethod = frame.GetMethod();
        Console.WriteLine($"Method: {sourceMethod.Name} - Class {sourceMethod.DeclaringType.FullName} : Location: {frame.GetILOffset()}");
    }
