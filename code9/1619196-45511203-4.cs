    public abstract class Direction {
         
    
        private class DirectionUp : Direction { }
        private class DirectionDown : Direction { }
        private class DirectionLeft : Direction { }
        private class DirectionRight : Direction { }
    
        public static Direction Up => new DirectionUp();
        public static Direction Down => new DirectionDown();
        public static Direction Left => new DirectionLeft();
        public static Direction Right => new DirectionRight();
    }
