     public class childBrick: Brick
     {
         public new float X 
         {
             get { return base.X - 1.0 } 
             private set { base.X = value; }
         }
         public static Brick Make( float x, float y)
         {
             return new childBrick
             { 
                X = x;
                Y = y;
             }
         }
     }
