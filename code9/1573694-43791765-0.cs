    List<Dobbelsteen> dices = new List<Dobbelsteen>()
    {
        {new Dobbelsteen()},
        {new Dobbelsteen()},
        {new Dobbelsteen()},
        {new Dobbelsteen()},
        {new Dobbelsteen()},
        {new Dobbelsteen()}
    };
    public void RollAll()
    {
        for (int i = 0; i < 6; i++)
            dices[i].Rollen();
    }
    public int GetDiceValue(int i)
    {
       if(i >= 0 && i <= dices.Count)
          return dices[i].Waarde;
       else
          throw new ArgumentException("Invalid index");
    }
