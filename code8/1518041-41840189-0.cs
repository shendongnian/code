        string line = string.Empty;
        while ((line = process.StandardOutput.ReadLine()) != null)
        {
            Console.WriteLine("CLI Says: " + line);
        }
