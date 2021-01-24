               //Get the sentence array
                var sentence = Console.ReadLine().Split(' ');
                var rearrangedSentence = new StringBuilder();
              
               //Get the length of longest word in array
                int loopLength = sentence.OrderBy(n => n.Length).Last().Length;
                int x = 0;
               // Run for the length of longest word
                for (int i = loopLength-1; i >=0 ; i--)
                {
                   // need to pick up an element at every run for each element.
                    for (var j = 0; j < sentence.Length; j++)
                    {
                        //Picking the position of item to be picked up   
                        int val = sentence[j].Length - (x + 1);
                        // If index not out of bounds
                        if(val >= 0 && val <= sentence[j].Length)
                         {
                            // Pick the character and append to stringbuilder.
                            rearrangedSentence.Append(sentence[j][val]);
                         }
                    }
                   // Next letter should be n-1, then n-2. 
                   // Increase this. Val will decrease
                    x++;
                }
    
                Console.WriteLine(rearrangedSentence.ToString());
    
    
                Console.ReadLine();
