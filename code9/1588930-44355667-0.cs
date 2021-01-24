     var lettersDictionary = new Dictionary<char, int>();
     for (int i = 0; i < numberofLetters; i++)
     {
         var currentLetter = kelime[i];
         if(lettersDictionary.ContainsKey(currentLetter))
         {
             // The dictionary contains the currentLetter. 
             // So we increase the times we found it by 1.
             lettersDictionary[currentLetter] += 1;
         }
         else
         {
             // The dictionary doesn't contain the currentLetter.
             // So we add the new key with the value of 1.
             lettersDictionary.Add(currentLetter,1);
         }
     }
