    using (StreamWriter writer = File.CreateText(TO_DO_LIST))
    {
        foreach (string text in itemsList.Items)
        {
            writer.WriteLine(text);
        }
    };
