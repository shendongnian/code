    List<List<GameObject>> gpl = new List<List<GameObject>>();
    List<GameObject> cbl = new List<GameObject>();
    GameObject c = new GameObject();
    cbl.Add(c);
    gpl.Add(cbl);
    
    Debug.WriteLine(cbl.IndexOf(c));
    Debug.WriteLine(gpl.IndexOf(cbl));
