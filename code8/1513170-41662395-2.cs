    private void LosujPytania()
    {            
        int a = losowa.Next(1,20);
        while (pula.Count < 10)
        {
            foreach (int i in pula)
            {
                if (a == i)
                {
                    a = losowa.Next(1, 20);
                    break;
                }
            }
            pula.Add(a);
        }
    }
