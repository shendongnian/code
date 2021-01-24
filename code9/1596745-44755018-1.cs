    public bool Intersects<U>(Octree<U> other)
    {
        if ( TryIs<Octree<Triangle>>(out var ota) && TryIs<Octree<Triangle>>(out var otb))
        {
            return ota.Intersects( otb, Triangle.Intersects );
        }
        throw new NotImplementedException();
    }    
 
