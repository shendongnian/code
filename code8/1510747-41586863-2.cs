     // abc - no quotation
     Console.WriteLine(CutQuotation("abc")); 
     // abc - simple quotation cut
     Console.WriteLine(CutQuotation("\"abc\"")); 
     // "abc" - double quotation
     Console.WriteLine(CutQuotation("\"\"abc\"\"")); 
     // a"bc - quotation in the middle
     Console.WriteLine(CutQuotation("\"a\"\"bc\"")); 
