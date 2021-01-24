    List<Dobbelsteen> dices = new List<Dobbelsteen>()
    {
        {new Dobbelsteen()},
        {new Dobbelsteen()},
        {new Dobbelsteen()},
        {new Dobbelsteen()},
        {new Dobbelsteen()}
    };
    public void RollAll()
    {
        for (int i = 0; i < 5; i++)
            dices[i].Rollen();
    }
    public int GetDiceValue(int i)
    {
       if(i >= 0 && i <= dices.Count)
          return dices[i].Waarde;
       else
          throw new IndexOutOfRangeException($"Invalid index {i}");
    }
    public void SetLock(int p)
    {
       if(p >= 0 && p <= dices.Count)
          return dices[p].Checked = true;
       else
          throw new IndexOutOfRangeException($"Invalid index {p}");
    }
