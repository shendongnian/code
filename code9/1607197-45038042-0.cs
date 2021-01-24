    void KillChicken(Chicken chicken)
    {
            chicken.Status = "Dead";
    }
    int[] testnummer = { 2,3,5,6};
    foreach(var ch in chickens.Where(c=>testnummer.Contains(c.Number))
           KillChicken(ch);
