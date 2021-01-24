    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    class MainClass {
        public static void Main (string[] args) {
           IList<string> names = "ShipTo/Dept#: 0011125227 - BIENVILLE SURGERY CENTER LLC SUITE 102 6300 EAST LAKE BLVD VANCLEAVE, Mississippi 39565".Split('-').Reverse().ToList<string>();
           Console.WriteLine(names[0]);
        }
    }
