     public class Fruit : IPeelable
     {
         public int NumberOfBananas = 10;
         public virtual void EatMe()
         {
             Console.WriteLine("I'm a fruit and I've been eaten");
         }
         public void PeelMe()
         {
             Console.WriteLine("I'm a fruit and I've been peeled");
         }
     }
     public class Banana : Fruit
     {
         public new int NumberOfBananas = 5;
         public override void EatMe()
         {
             Console.WriteLine("I'm a banana and I've been eaten");
         }
         public new void PeelMe()
         {
             Console.WriteLine("I'm a banana and I've been peeled");
         }
     }
    
     private static void Main()
     {
         Fruit banana = new Banana();
         Console.WriteLine(banana.NumberOfBananas);          // Result: 10
    
         Banana realBanana = (Banana)banana;
         Console.WriteLine(realBanana.NumberOfBananas);      // Result: 5
    
         Fruit bananaFruit = (Fruit)realBanana;
         Console.WriteLine(bananaFruit.NumberOfBananas);      // Result: 10
    }
