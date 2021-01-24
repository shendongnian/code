    using System.Text.RegularExpressions;
    string textFile = System.IO.File.ReadAllText(@"C:\Users\example\Downloads\text.txt");
    var wdRx = new Regex(@"\W+");
    List<string> words = new List<string>(wdRx.Split(txtFile));
    foreach (var wd in words)
    {
          Console.WriteLine(wd);
    }
