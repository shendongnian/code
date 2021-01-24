    abstract class GameObject {
        public virtual void Move() { }
        public virtual void Collide() { }
    }
    
    sealed class Player : GameObject {
        public override void Move()
            => _collisionLogic.Move();
    
        private readonly CollisionLogic _collisionLogic = new CollisionLogic(this);
    }
