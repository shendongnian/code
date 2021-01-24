    public class Character
    {
         public string Name {get; set;}
         public int Health {get; set;}
         public int Boredom {get; set;}
         public int Sleep {get; set;}
         public int Hunger {get; set;}
         public string Status
         {
              get
              {
                   if(Boredom >= Hunger && Boredom >= Sleep)
                   {
                        return "Bored";
                   }
                   if(Hunger >= Boredom && t.Hunger >= Sleep)
                   {
                        return "Hungry";
                   }
                   if(Sleep >= Boredom && Sleep >= Hunger)
                   {
                        return "Sleepy";
                   }
                   return "Geen status";
              }
    }
