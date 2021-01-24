        public static IEnumerable<T> Shuffle<T>(this IEnumerable<T> input)
        {
            var buffer = input.ToArray();
            //Math.Random is OK for "everyday" randomness;
            //use RNGCryptoServiceProvider if you need 
            //cryptographically-strong randomness
            var rand = new Random();
            //As the loop proceeds, the element to output will be randomly chosen
            //from the elements at index i or above, which will then be swapped 
            //with i to get it out of the way; the yield return gives us each 
            //shuffled value as it is chosen, and allows the shuffling to be lazy.
            for (int i = 0; i < buffer.Length; i++)
            {
                int j = rand.Next(i, buffer.Length);
                yield return buffer[j];
                //if we cared about the elements in the buffer this would be a swap,
                //but we don't, so...    
                buffer[j] = buffer[i];
            }
        }
        ...
 
        string[] fileLines = GetLinesFromFile(fileName); //a StreamReader makes this pretty easy
        var randomLines = fileLines.Shuffle().Take(n);
