    private void button_Click(object sender, RoutedEventArgs e)
    {
        AllocConsole();
        using (Stream stream = Console.OpenStandardInput())
        using (TextReader reader = new StreamReader(stream))
        {
            string x = reader.ReadLine();
        }
        FreeConsole();
    }
