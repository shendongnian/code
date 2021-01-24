    public static bool operator ==(Weapon w1, Weapon w2)
    {
        return Equals(w1, w2);
    }
    public static bool operator !=(Weapon w1, Weapon w2)
    {
        return !Equals(w1, w2);
    }
