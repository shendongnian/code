            static int[] Shuffle(int[] a)
        {
            Random rnd = new Random();
            //Remove duplicates from array
            int[] distinct = a.Distinct().ToArray();
            //Add the same amount of unique numbers that have been removed as duplicates
            int len = a.Length - distinct.Length;
            int[] newNumbers = new int[len];
            int i = 0;
            while(i < len)
            {
                newNumbers[i] = rnd.Next(a.Length); //NOTE: here i put in the length of array a, but with an int array this will always resolve in a shuffled array containing all digits from 0 to the length-1 of the array.
                if (!distinct.Contains(newNumbers[i])  && !newNumbers.Take(i).Contains(newNumbers[i]))
                {
                    ++i;
                }
            }
            //Randomize the array           
            int[] b = a.OrderBy(x => rnd.Next()).ToArray();
            //Concatenate the two arrays and return it (shuffled numbers and new unique numbers)
            return distinct.Concat(newNumbers).ToArray();
        }
