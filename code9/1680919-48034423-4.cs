    public class WorldMarket() 
    {
        // various class constructor methods
 
        
        public int IsNation(string country)
        {
            // you could access Nations directly here
            for (int i = 0; i < Nations.Count; i++)
            {
                if (Nations[i].Name == country)
                {
                    return 1;
                }
                // else { return 0; } -- this would exit the loop unnecessarily
            }
            return 0;
        }
    }
