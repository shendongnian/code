    public static List<int> SquareList(ref List<int> root)
    {
        root = root.Select(x => x*x).ToList();
        return root;
    }
