    public static void DepthFirst(int Depth,
                                  int CurrentDepth,
                                  Person iRoot,
                                  List<string>[] Result)
    {
        string[] NewEntry = new string[Depth];
        NewEntry[CurrentDepth] = iPerson.Name;
        Result.Add(NewEntry);
        foreach(var iChild in iPerson.Children)
        {
            DepthFirst(Depth, CurrentDepth + 1, iChild, Result);
        }
    }
    int Depth = iRoot.Depth();
    var Result = new List<string[]>();
    DepthFirst(Depth, 0, iRoot, Result).
    
    
