    public class Board
    {
        List<Piece> pieces;
    }
    public abstract class Piece
    {
         //Some base behavior/interface
         public bool Move(int xTarget, int yTarget)
         {
             if (IsValidMove(xTarget, yTarget))
             {
                //Do stuff
             }
         }
         protected abstract bool IsValidMove(int xTarget, int yTarget);
    }
