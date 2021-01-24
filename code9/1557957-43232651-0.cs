    public override int GetHashCode()
    {
        unchecked
        {
            return SafeHashCode(OriginalRoomCode) ^
                   SafeHashCode(RoomCode) ^ 
                   Attributes.Select(x => SafeGetHashCode(x)).Aggregate((seed, current) => seed ^ current);
        }
    }
