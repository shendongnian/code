    private Task drawGraph = null;
    ...
    if (selectedTabIndex == 2)
    {
      if (drawGraph != null)
        await drawGraph;
      DrawGraph obj = new DrawGraph(selectedItem.Name);
      drawGraph = obj.timeConsumingProcess();
    }
    ...
    private readonly string name;
    public DrawGraph(string Name)
    {
      name = Name;
    }
    public async Task timeConsumingProcess()
    {
      await  startTaimeConsumingProcess();
    }
