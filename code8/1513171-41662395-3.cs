    private void LosujPytania()
    {            
        int a = losowa.Next(1,20);
        pula.Add(a);
        while (pula.Count < 10)
        {
            do
            {
                a = losowa.Next(1, 20);
            } while(pula.Contains(a));
    
            pula.Add(a);
        }
    }
