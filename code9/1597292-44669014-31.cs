    interface IGameObject { }
    interface ICollidable : IGameObject { }
    abstract ComposedPhysicalObject : ICollidable {
        public void Collide() {
            foreach (var part in Parts.OfType<ICollidable>())
                part.Collide();
        }
    
        public List<IGameObject> Parts { get } = new List<IGameObject>()
    }
