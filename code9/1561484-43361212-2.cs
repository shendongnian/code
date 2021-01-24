    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;
    class MainClass {
         public static void Main (string[] args) {
         IList<string> names = "ShipTo/Dept#: 0011125227 - BIENVILLE SURGERY CENTER LLC SUITE 1022 asdf 6300 EAST LAKE BLVD VANCLEAVE, Mississippi 39565".Split('-').Reverse().ToList<string>();
  
  
         string character = Regex.Match(names[0], @"^[^0-9]*").Value.Trim();
         string number = new string(names[0].SkipWhile(c=>!char.IsDigit(c)).TakeWhile(c=>char.IsDigit(c)).ToArray());
  
         Console.WriteLine(character+" "+number);
         }
    }
