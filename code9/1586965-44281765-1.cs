    string text = string.Join(",", Enumerable.Range(0, 1111).Select(i => "123456789"));
    var phoneNumbersIn100Groups = text.SplitByLength(new[] { "," }, StringSplitOptions.None, 100);
    foreach (string[] part in phoneNumbersIn100Groups)
    {
        Assert.IsTrue(part.Length <= 100);
        Console.WriteLine(String.Join("|", part));
    }
