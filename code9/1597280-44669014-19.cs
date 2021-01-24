    abstract class PhysicalObject : IMoveable, ICollidable {
            public virtual void Move() { }
            public virtual void Collide() { }
    }
    
    abstract class SentientEntity : PhysicalObject, IAi
    {
            public virtual void Ai() { }
    }
    
    class Enemy : SentientEntity {
    }
    
    class Player : SentientEntity {
    }
    
    class Friend : SentientEntity {
    }
