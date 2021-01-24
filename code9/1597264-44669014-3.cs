    class Enemy : IMoveable, ICollidable {
        public void Move()
        {
            _moveable.Move();
        }
        private readonly IMoveable _moveable = new Moveable();
    }
