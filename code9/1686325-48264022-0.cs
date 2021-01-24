     private readonly object generateBodyColliderLockObject = new object();
     protected virtual void GenerateBodyCollider()
     {
          lock (generateBodyColliderLockObject)
          {
