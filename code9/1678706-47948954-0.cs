    private static Random random = new Random();
        
    private void trouverMot()
    {
        while (true) 
        {
            int index = random.Next(0,maList.Count);
            mot = (maList[index].Trim());
            if (niveau == "Facile")
            {
                if (mot.Length > 6 || lstUse.Contains(mot))
                {
                    continue;
                }
            }
            else
            {
                if (mot.Length < 6 || lstUse.Contains(mot))
                {
                    continue;
                }
            }
        }
    
        lstUse.Add(mot);
        affichage();
    }
