    for (int i = 0; i < An.Count; i++) {
        if (An[i + 1] != An[i] + 1) {
           missing.Add(An[i] + 1);
           An.Insert(i + 1, An[i] + 1); // this will break your algorithm
    }
