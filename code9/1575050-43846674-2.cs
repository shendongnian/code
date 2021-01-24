    // TEST DATA
    List<int> listaId = Enumerable.Range(1, 420).ToList();
    List<string> listaZapytan = new List<string>();
    int stepsize = 200;
    for (int i = 0; i < listaId.Count; i +=stepsize)
    {
        listaZapytan.Add("?ids=" + String.Join(",", listaId.Skip(i).Take(stepsize)));
    }
