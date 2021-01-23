        public class Coord : IEquatable<Coord>
        {
            public Coord(int x, int y)
            {
                this.X = x;
                this.Y = y;
            }
            public int X { get; }
            public int Y { get; }
            public override int GetHashCode()
            {
                object.Equals("a", "b");
                // Just pick numbers that are prime between them
                int hash = 17;
                hash = hash * 23 + this.X.GetHashCode();
                hash = hash * 23 + this.Y.GetHashCode();
                return hash;
            }
            public override bool Equals(object obj)
            {
                var casted = obj as Coord;
                if (object.ReferenceEquals(this, casted))
                {
                    return true;
                }
                return this.Equals(casted);
            }
            public static bool operator !=(Coord first, Coord second)
            {
                return !(first == second);
            }
            public static bool operator ==(Coord first, Coord second)
            {
                if (object.ReferenceEquals(second, null))
                {
                    if (object.ReferenceEquals(first, null))
                    {
                        return true;
                    }
                    return false;
                }
                return first.Equals(second);
            }
            public bool Equals(Coord other)
            {
                if (object.ReferenceEquals(other, null))
                {
                    return false;
                }
                return object.ReferenceEquals(this, other) || (this.X.Equals(other.X) && this.Y.Equals(other.Y));
            }
        }
