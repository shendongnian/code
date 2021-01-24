    var set = new HashSet<Task>(new TaskComparer());
    for (int i = thisProject.Tasks.Count - 1; i >= 0; --i) {
        if (!set.Add(thisProject.Tasks[i]))
            thisProject.Tasks[i].Delete();
    }
