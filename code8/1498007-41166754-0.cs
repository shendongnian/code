    public override bool Equal(Object o) {
      if (object.ReferenceEquals(o, this))
        return true;
      Coordinate other = o as Coordinate;
      else if (null == other) 
        return false; 
      return x == other.x && y == other.y;
    }
    public override int GetHashCode() {
      return x.GetHashCode() ^ y.GetHashCode();
    }
