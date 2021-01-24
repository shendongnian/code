    Quaternion slerp(Quaternion v0, Quaternion v1, double t) {
        // Only unit quaternions are valid rotations.
        // Normalize to avoid undefined behavior.
        v0.normalize();
        v1.normalize();
    
        // Compute the cosine of the angle between the two vectors.
        double dot = dot_product(v0, v1);
    
        const double DOT_THRESHOLD = 0.9995;
        if (fabs(dot) > DOT_THRESHOLD) {
            // If the inputs are too close for comfort, linearly interpolate
            // and normalize the result.
    
            Quaternion result = v0 + t*(v1 – v0);
            result.normalize();
            return result;
        }
    
        // If the dot product is negative, the quaternions
        // have opposite handed-ness and slerp won't take
        // the shorter path. Fix by reversing one quaternion.
        if (dot < 0.0f) {
            v1 = -v1;
            dot = -dot;
        }  
    
        Clamp(dot, -1, 1);           // Robustness: Stay within domain of acos()
        double theta_0 = acos(dot);  // theta_0 = angle between input vectors
        double theta = theta_0*t;    // theta = angle between v0 and result 
    
        Quaternion v2 = v1 – v0*dot;
        v2.normalize();              // { v0, v2 } is now an orthonormal basis
    
        return v0*cos(theta) + v2*sin(theta);
    }
