    CompoundShape collisionShape = ConvexDecomposition(compModel.Children[i].Id, vertices, indices);
    
    // Set collision shape
    collisionData.RigidBody.CollisionShape = collisionShape;
    
    // Set position
    collisionData.RigidBody.MotionState.WorldTransform *= collisionData.PositionDifference;
    
        // Add rigid body to world
    _world.AddRigidBody(collisionData.RigidBody, collisionData.CollisionGroup, collisionData.CollisionMask);
