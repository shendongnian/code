            do
            {
                for (var i = 1; i <= text.Length; i++)
                {
                    if (i % 2 == 0)
                    {
                        everySecondLetter += text[i - 1];
                    }
                    else
                    {
                        otherLetters += text[i - 1];
                    }
                }
                text = everySecondLetter + otherLetters;
                //*** Add these two lines:
                everySecondLetter = "";
                otherLetters = "";
                iterate++;
                Console.WriteLine(text);
            } while (iterate <= n);
    
