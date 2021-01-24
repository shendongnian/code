    abstract ComposedPhysicalObject : ICollidable {
        public void Collide() {
            Parts.ForEach(part => part.Collide());
        }
    
        public List<ICollidable> Parts { get } = new List<ICollidable>()
    }
