    public new bool Equals(object obj) {
        if (obj == this) return true;
        var other = obj as ProdRow;
        if (other == null) return false;
        return Code.Equals(other.Code) && Quantity == other.Quantity;
    }
    public int GetHashCode() {
        return 31*Code.GetHashCode() + Quantity;
    }
