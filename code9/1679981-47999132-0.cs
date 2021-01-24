    private bool IsApproachingTarget(double epsilon)
    {
    	float prevDist, currDist;
    	Vector3.DistanceSquared(ref this.previousPosition, ref target.previousPosition, out prevDist);
    	Vector3.DistanceSquared(ref this.currentPosition, ref target.currentPosition, out currDist);
    	return IsLess(currDist, prevDist, epsilon);
    }
    
    
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    /// <summary>
    /// Robust implementation of a &lt; b, handling floating point imprecisions
    /// </summary>
    public bool IsLess(double a, double b, double epsilon)
    {
    	return a < b - epsilon;
    }
