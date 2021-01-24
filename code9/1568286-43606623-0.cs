    var splittedString = tekstas.Split(new[] { Environment.NewLine }, StringSplitOptions.None);
    var max = splittedString.Max(x => x.Length);
    var min = splittedString.Min(x => x.Length);
    var maxLengthString = splittedString.Where(x => x.Length == max);
    var minLengthString = splittedString.Where(x => x.Length == min);
