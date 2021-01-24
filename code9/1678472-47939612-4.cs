    string input = "Hello world (707)(y)(9) ";
    System.Text.RegularExpressions.Regex re = new
    System.Text.RegularExpressions.Regex("[;\\\\/:*?\"<>|&'()-]");
    //split
    var x = re.Split(input);
    //rebuild
    var newString = string.Join(" ", x.Where(c => !string.IsNullOrWhiteSpace(c))
                                      .Select(c => c.Trim()));
