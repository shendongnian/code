            int totalVowels = 0;
            int totalConsonants = 0;
            int wordCount = 0, index = 0;
            var vowels = new HashSet<char> { 'a', 'e', 'i', 'o', 'u' };        
            for (int i = 0; i < sentence.Length; i++)
                    if (vowels.Contains(sentence[i]))
                    {
                        totalVowels++;
                    }
                    else 
                    {
                        totalConsonants++;
                    }
                }
                Console.WriteLine("Your total number of vowels is: {0}", totalVowels);
                Console.WriteLine("Number of consonants: {0}", totalConsonants);
                Console.ReadLine();
`
