    public class AggregatesDirection {
         public Direction Dir { public get; private set; }
    
        public AggregatesDirection() {
             Dir = Direction.Up; //uses the static property in Direction that will use the private constructor of the private class in Direction.
        }
    }
