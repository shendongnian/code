    public List<VW_COLLISIONS_TS> GetCollisions(string collisionMRN)
     {
           int collision = int.Parse(collisionMRN);
           var collisions = (from c in TSP_Context.VW_COLLISIONS_TS
                where .COLLISION_MASTER_RECORD_NUMBER == collision
                              select c).AsNoTracking();
    
    
           return collisions.ToList();
     }
