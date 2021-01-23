    class Node
    {
        int snakeHead ;   // points to another node where the player goes down to 
        int ladderFoot;  // points to another node where to player goes up to
        public int SnakeHead
        {
            get { return snakeHead;}
            set { snakeHead = value;}
        }
 
        public int LadderFoot
        {
            get { return ladderFoot; }
            set { ladderFoot = value;}
        }
    }
