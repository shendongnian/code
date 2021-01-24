            public static void split(string number)
            {
            Dictionary<string, string> dict = new Dictionary<string, string>();
            string s = "ABCDEF";
            
            for (int i = 0; i < 6; i++)
            {
                dict.Add( s[i].ToString()  , number[i].ToString()); // Here you add each char of the string ABCDEF, to the value from each char of the number. In this case A=2.
                Console.WriteLine($"LETTER { s[i].ToString()} =  { dict[s[i].ToString()]  }" ); // Here you print the values of your dictionary, if you want to call a value of your dictionary, you only have to say: dictionaryname[key], in this case, dictionaryname['A']
            }
           }
