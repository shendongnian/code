            public bool Equals(Team other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return string.Equals(this.Name, other.Name) && Equals(this.Opponents, other.Opponents);
        }
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Team)obj);
        }
        public override int GetHashCode()
        {
            unchecked
            {
                return ((this.Name != null ? this.Name.GetHashCode() : 0) * 397) ^ (this.Opponents != null ? this.Opponents.GetHashCode() : 0);
            }
        }
        public static bool operator ==(Team left, Team right)
        {
            return Equals(left, right);
        }
        public static bool operator !=(Team left, Team right)
        {
            return !Equals(left, right);
        }
