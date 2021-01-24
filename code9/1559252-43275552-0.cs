    TreeList T1 = new TreeList("");
    TreeList T2 = new TreeList("");
    T1.Add(T2);
    T2.Add(T1);
    bool contrains = T2.Items.Any(x => x.Equals(T1));
