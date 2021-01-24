    public enum Direction {
        1 = Up,
        2 = Right,
        3 = Down,
        4 = Left
    }
    
    public class UseDirection {
        public Direction Dir { public get; private set; }
    
        public void SetDirection(Direction dir) {
             Dir = dir;
        }
    }
