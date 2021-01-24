    class AnimNameEqualityComparer: EqualityComparer<AnimName>
    {
	    public override bool Equals(AnimName a1, AnimName a2)
	    {
		     return a1.Value.Equals(a2.Value)
	    }
	    public override int GetHashCode(AnimName a)
	    {
		    return a.Value.GetHashCode();
	    }
    }
