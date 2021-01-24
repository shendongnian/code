    public abstract class Direction {
         
    
        private class DirectionUp : Direction { }
        private class DirectionDown : Direction { }
        private class DirectionLeft : Direction { }
        private class DirectionRight : Direction { }
    
        public static DirectionUp Up => new DirectionUp();
        public static DirectionDown Down => new DirectionDown();
        public static DirectionLeft Left => new DirectionLeft();
        public static DirectionRight Right => new DirectionRight();
    }
