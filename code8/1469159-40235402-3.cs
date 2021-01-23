    public class WaterTile : Tile
    {
      //all property and functions now are accessible from the Tile base class
      private string somevariable;
      public string Somevariable
       { 
       get{return somevariable;} 
       set{somevariable=value;}
       }
      public override string someFunction()
      {
           //return "something";
      }
    }
    public class SailTile : WaterTile
        { //if there are additional properties/functions in your WaterTile it will be accessible by this class (SailTile) but not to other class
           //in this case Somevariable is accessible in this class
        }
