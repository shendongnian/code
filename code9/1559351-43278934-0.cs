    List<List<double>> values; //Assuming this one is populated and ready to use like this
    List<double> allValuesInOneSingleList = new List<double>();
    foreach(List<double> list in values)
    {
        allValuesInOneSingleList.AddRange(list);
    }
