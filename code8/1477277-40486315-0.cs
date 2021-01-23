    var path = @"C:\MY FOLDER\data.txt";
    //Create the file if it doesn't exist
    if (!File.Exists(path)) 
    {
        using (var sw = File.CreateText(path))
        {
            sw.WriteLine("Hello, I'm a new file!!");
            // You don't need this as the using statement will close automatically, but it does improve readability
            sw.Close();
        }
    }
    using (var sw = File.AppendText(path))
    {
        for (int i = 0; i < 10; i++)
        {
            sw.WriteLine(string.Format("Line Number: {0}", i));
        }
    }
