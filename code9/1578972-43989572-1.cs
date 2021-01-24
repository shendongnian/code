    class Foo : IEquatable<Foo>
    {
        public int ID;
        public string Description;
        public long Location;
        public bool Equals(Foo other)
        {
            // Whatever your logic is
            return this.Description == other.Description && this.ID == other.ID && this.Location == other.Location;
        }
    }
    List<Foo> filteredFooList = fooList.Where(f => !f.Equals(fooFilter));
