    List<string> newPermutations = new List<string>();
    for(int a = 0; a!=inString.Count; a++)
        for((int b = 0; b!=inString.Count; b++)
            if(noRepetitions && a == b) continue;
            newPermutations.Add(""+inString[a] + inString[b]);
