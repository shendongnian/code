    using System.Text.RegularExpressions;
    
    /// <summary>
    ///  Regular expression built for C# on: Mon, May 29, 2017, 02:24:58 PM
    ///  Using Expresso Version: 3.0.5854, http://www.ultrapico.com
    ///  
    ///  A description of the regular expression:
    ///  
    ///  \[text_box title="
    ///      Literal [
    ///      text_box
    ///      Space
    ///      title="
    ///  [title]: A named capture group. [.*?]
    ///      Any character, any number of repetitions, as few as possible
    ///  " align="
    ///      "
    ///      Space
    ///      align="
    ///  [align]: A named capture group. [.*?]
    ///      Any character, any number of repetitions, as few as possible
    ///  ".*\]
    ///      "
    ///      Any character, any number of repetitions
    ///      Literal ]
    ///  [data]: A named capture group. [.*]
    ///      Any character, any number of repetitions
    ///  \[\/text_box\]
    ///      Literal [
    ///      Literal /
    ///      text_box
    ///      Literal ]
    ///  
    ///
    /// </summary>
    public static Regex regex = new Regex(
          "\\[text_box title=\"(?<title>.*?)\" align=\"(?<align>.*?)\"."+
          "*\\](?<data>.*)\\[\\/text_box\\]",
        RegexOptions.Singleline
        | RegexOptions.CultureInvariant
        | RegexOptions.Compiled
        );
    
    
    // This is the replacement string
    public static string regexReplace = 
          "<div class=\"text-box align${align}\"><h4>${title}</h4>";
    
    
    //// Replace the matched text in the InputText using the replacement pattern
    string result = regex.Replace(InputText,regexReplace);
    
    //// Split the InputText wherever the regex matches
     string[] results = regex.Split(InputText);
    
    //// Capture the first Match, if any, in the InputText
     Match m = regex.Match(InputText);
    
    //// Capture all Matches in the InputText
     MatchCollection ms = regex.Matches(InputText);
    
    //// Test to see if there is a match in the InputText
     bool IsMatch = regex.IsMatch(InputText);
    
    //// Get the names of all the named and numbered capture groups
     string[] GroupNames = regex.GetGroupNames();
    
    //// Get the numbers of all the named and numbered capture groups
     int[] GroupNumbers = regex.GetGroupNumbers();
