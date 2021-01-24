    string s1 = "abcdefg";
    string s2 = "acceeff";
    
    // Write each input string to console.
    Console.WriteLine(s1);
    Console.WriteLine(s2);
    
    // Loop each character and check for match.
    for(int i = 0; i < s1.Length; i++)
    {
        if(s1[i] == s2[i]) // If match output "."
            Console.Write(".");
        else // otherwise, output "*"
            Console.Write("*");
    }
    
    // Write a new line ready for the next test case.
    Console.WriteLine();
