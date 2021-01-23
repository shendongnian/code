    var indexes = new List<int>();
    while (i < words.Length) {
        foreach (string verb in verbs) {
            if (words[i] == verb) {
                int index = i;
                indexes.Add(i);
                break;
            }
        }
        i++;
    }
