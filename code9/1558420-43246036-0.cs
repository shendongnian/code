    StringBuilder sb = new StringBuilder();
    StringWriter sw = new StringWriter(sb);
    // Save the standard output.
    TextWriter tmp = Console.Out;
    Console.SetOut(sw);
    // Code which calls Console.Write
    Console.SetOut(tmp);
    string actual = sb.ToString();
