    class EntityComparer : IEqualityComparer<Entity>
    {
        public bool Equals(Entity x, Entity y) => x.Id.Equals(y.Id);
        public int GetHashCode(Entity obj) => base.GetHashCode();
    }
