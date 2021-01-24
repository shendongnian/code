    abstract class PhysicalObject : IMoveable, ICollidable {
            public virtual void Move() { }
            public virtual void Collide() { }
    }
    
    abstract class SentientEntity : PhysicalObject, IAi
    {
            public virtual void Ai() { }
    }
    
    sealed class Enemy : SentientEntity {
    }
    
    sealed class Player : SentientEntity {
    }
    
    sealed class Friend : SentientEntity {
    }
