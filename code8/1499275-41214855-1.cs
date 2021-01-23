    using System;
    using System.Text.RegularExpressions;
    
    class RemovePaths
    {
        static void Main()
        {
            string input = @"
    PERFORMER ""Charles Lloyd""
    
    TITLE ""Mirror""
    
    FILE ""Charles Lloyd\[2010] Mirror\01. I Fall In Love Too Easily.wav"" WAVE
    
    TRACK 01 AUDIO
    
    FILE ""Charles Lloyd\[2010] Mirror\02. Go Down Moses.wav"" WAVE";
    
            string test = @"
    PERFORMER ""Charles Lloyd""
    
    TITLE ""Mirror""
    
    FILE ""01. I Fall In Love Too Easily.wav"" WAVE
    
    TRACK 01 AUDIO
    
    FILE ""02. Go Down Moses.wav"" WAVE";
    
            Regex rgx = new Regex(@"(?<=\"").*\\(?=.+\"")");
            string result = rgx.Replace(input, "");
            Console.WriteLine(result == test ? "Pass" : "Fail");
        }
    }
       
