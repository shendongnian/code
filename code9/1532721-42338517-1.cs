        List<State> list = new List<State>();
        var file = File.ReadAllLines(FilePath).ToList();
        foreach (var item in file)
        list.Add(new State()
        {
           stateName = item.Split(':')[0],
           capital = new Capital() { capitalName = item.Split(':')[1] }
         });
        StatesCB.DataSource = list.Select(x => x.stateName).ToList();
