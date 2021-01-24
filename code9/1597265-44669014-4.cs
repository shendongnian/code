    abstract class PhysicalObject : IMoveable, ICollidable {
            protected PhysicalObject()
            {
                _moveable = CreateMoveableBehavior();
                _collidable = CreateCollidableBehavior();
            }
            public void Move() => _moveable.Move();
            public void Collide() => _collidable.Collide();
            protected virtual IMoveable CreateMoveableBehavior()
                => new Moveable();
            protected virtual ICollidable CreateCollidableBehavior()
                => new Collidable();
            private readonly IMoveable _moveable;
            private readonly ICollidable _collidable;
    }
