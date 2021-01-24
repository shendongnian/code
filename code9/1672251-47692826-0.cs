    // Main entrance
    public void DoStuff()
    {
        // define variations 
        List<string> possibilities = new List<string>() { "0", "1", "2", "3", "4", "5" };
        // resultlist, will be filled later
        List<string> permutations = new List<string>();
        // how many values will be taken from the possibilities
        int digits = 5;
        //do the work
        Permute(permutations, possibilities, digits, "");
        // display the work
        foreach (var item in permutations)
        {
            Console.WriteLine(item);
        }
    }
    /// <summary>
    /// generates a List of permuted strings
    /// </summary>
    /// <param name="permutations">resultlist</param>
    /// <param name="possibilities">possible values of the digit</param>
    /// <param name="digitsLeft">how many digits shall be appended</param>
    /// <param name="current">the current value of the unfinished result</param>
    private void Permute(List<string> permutations, List<string> possibilities, int digitsLeft, string current)
    {
        // uncomment to see how it works in detail
        //Console.WriteLine("step:"+current);
        // most important: define Stop conditions for the recursion
        // safety stop
        if (digitsLeft < 0)
        {// end of digits :), normally we never end up here
            return;
        }
        // normal stop
        if (digitsLeft == 0)
        {// normal endpoint, add the found permutation to the resultlist
            permutations.Add(current);
            return;
        }
        // now prepare the recursion, try each possibility
        foreach (var item in possibilities)
        {
            // digitsLeft need to be decreased, since we add a concrete digit to the current value (current+item)
            // important: (current + item) generates a new string in memory, the old values won't be touched, permutations possibilities are references, so no memory impact here
            Permute(permutations, possibilities, digitsLeft - 1, current + item);
        }
    }
