    List<string> _Items = new List<string> { "maize", "meat" };
    List<string> _Uprices = new List<string> { "$50", "$100" };
    //                                         For prior c# 6 use here string.Format
    var lines = _Items.Zip(_Uprices, (item, price) => $"{item}  {price}").ToList();
    using (var stream = File.CreateText(@"C:\myfile.txt"))
    {
        lines.ForEach(stream.WriteLine);
    }
    //Output:
    // maize  $50
    // meat   $100
