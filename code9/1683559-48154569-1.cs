    public virtual RigidBody LocalCreateRigidBody(float mass, Matrix startTransform, CollisionShape shape)
            {
    
                //rigidbody is dynamic if and only if mass is non zero, otherwise static
                bool isDynamic = (mass != 0.0f);
    
                Vector3 localInertia = Vector3.Zero;
                if (isDynamic)
                    shape.CalculateLocalInertia(mass, out localInertia);
    
                //using motionstate is recommended, it provides interpolation capabilities, and only synchronizes 'active' objects
                DefaultMotionState myMotionState = new DefaultMotionState(startTransform);
    
                RigidBodyConstructionInfo rbInfo = new RigidBodyConstructionInfo(mass, myMotionState, shape, localInertia);
                RigidBody body = new RigidBody(rbInfo);
                rbInfo.Dispose();
                
                           
                return body;
            }
