    string input=
    @"Brightness 36 , Manual
    BacklightCompensation 3 , Manual
    ColorEnable 0 , None
    Contrast 16 , Manual
    Gain 5 , Manual
    Gamma 122 , Manual
    Hue 0 , Manual
    Saturation 100 , Manual
    Sharpness 2 , Manual
    WhiteBalance 5450 , Auto";
    string regEx =@"(.*) (\d+) , (.*)";
    var RegexMatch = Regex.Matches(input, regEx).Cast<Match>();
    var outputlist = RegexMatch.Select(x => new { setting = x.Groups, value = x.Groups[2].Value, mode = x.Groups[3].Value }); 
