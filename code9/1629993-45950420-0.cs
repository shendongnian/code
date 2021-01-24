    public class Goose
    {
         public Wings MyWings {get;set;}
         public void Eat()
         {
             //.. eat before flying
         }
         public void Fly()
         {
             //.. flap wings
         }
    }
    public class Airplane
    {
         public Engine MyEngine {get;set;}
         public void FuelUp ()
         {
             //.. fuel up before flying
         }
         public void Fly()
         {
             //.. start engine and accelerate
         }
    }
    public class SpruceGoose: Goose, Airplane
    {
        
        public void SomeMethod()
        {
            this.Fly();   // do I flap my wings? 
                          // or do I start my engine and accelerate 
                          // or do I do both? which one first
                          // do I eat? or do I fuel up?
        }
    }
