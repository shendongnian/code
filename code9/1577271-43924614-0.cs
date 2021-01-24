    //Total Bottle Weight
    public int findTotalWeight(Flaske[] kasse)
    {
            int result = 0;                
            int i = 0;
            while (i < kasse.Length)
            {
                if (kasse[i] != null)
                    result = result + kasse[i].weight;
                i = i + 1;
            }
            return result;            
    }
    //Find Coca Cola Weight
    public int findCocaColaWeight(Flaske[] kasse)
    {
            int result = 0;                
            int i = 0;
            while (i < kasse.Length)
            {
                if (kasse[i] != null && kasse[i].name.Equals("Coca Cola"))
                    result = result + kasse[i].weight;
                i = i + 1;
            }
            return result;            
    }
