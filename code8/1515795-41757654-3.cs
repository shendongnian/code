    string message = String.Empty;
    DataSet resultDataset = SelectDataSet("query here", false, out message);
    if (resultDataset != null)
    {
        Console.WriteLine(message);
        // proceed with resultDataset
    }
    else
    {
        Console.WriteLine(message);
    }
