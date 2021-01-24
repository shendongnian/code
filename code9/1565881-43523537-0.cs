    public class Player
    {
         private readonly Random dice;
         public Player(Random dice)
         {
             Debug.Assert(dice != null);
             this.dice = dice;
         }
         public int RollDice() => dice.Next(1, 7);
    }
