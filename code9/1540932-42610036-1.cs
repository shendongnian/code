    List<string> items = new List<string>();
    for (int i = 0; i <= items.Count / 20; i++)
    {
          List<string> smallList = items.Skip(i * 20).Take(20).ToList();
          smallList.AsParallel().ForAll(sm => CustomVoid(sm));
    }
