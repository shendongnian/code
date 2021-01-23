    var files = new[] { "SampleCSVFile_5300kb1.csv,SampleCSVFile_5300kb2.csv", "SampleCSVFile_5300kb3.csv" };
    var counter = 1;
    var dictionary = new Dictionary<string, string>();
    foreach (var file in files)
    {
        if (string.IsNullOrWhiteSpace(file))
        {
            continue;
        }
        foreach (var item in file.Split(new[] { "," }, StringSplitOptions.RemoveEmptyEntries))
        {
            dictionary.Add(item, "CSV" + counter);
        }
                
        counter++;
    }
