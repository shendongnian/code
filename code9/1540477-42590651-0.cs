     List<List<int>> ListOfLists = new List<List<int>>();
     List<int> TheList = new List<int>();
     for (int i = 1; i <= 30; i++)
     {
        TheList.Add(i);
        if (TheList.Count < 10)
           Console.WriteLine(i.ToString() + " adicionado");
        else
        {
           ListOfLists.Add(TheList);
           TheList = new List<int>();
        }
     }
