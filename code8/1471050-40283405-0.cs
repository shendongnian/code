     static int[] Run(int[] greaterArray, int[] lesserArray)
            {
                for (int i = 0; i <= greaterArray.Length - lesserArray.Length; i++)
                {
                    if (greaterArray.Skip(i).Take(lesserArray.Length).SequenceEqual(lesserArray))
                    {
                        return greaterArray.Take(i).Concat(greaterArray.Skip(i + lesserArray.Length)).ToArray();
                    }
    
                }
    
                return greaterArray;
            }
    
