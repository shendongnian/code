    class Owner
    {
        private int field;
        class Nested
        {
            public Nested(Owner owner) { this.owner = owner; }
            Owner owner;
            public int D()
            {
                return owner.field;
            }
        }
    }
