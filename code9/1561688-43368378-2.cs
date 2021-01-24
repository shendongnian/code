    public override int GetHashCode() {
        unchecked {
            return ((First != null ? First.GetHashCode() : 0) * 397) ^ (Second != null ? Second.GetHashCode() : 0);
        }
    }
