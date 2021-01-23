    int[] greaterArray = {8, 2, 4, 5, 9, 12, 3, 4, 5};
    int[] lesserArray = {3, 4, 5};
    for (int i = 0; i <= greaterArray.Length - lesserArray.Length; i++)
                {
                    var sub = greaterArray.SubArray(i, lesserArray.Length);
                    if (Enumerable.SequenceEqual(sub, lesserArray))
                    {
                        Console.WriteLine("Equals!");
                    }
                }
