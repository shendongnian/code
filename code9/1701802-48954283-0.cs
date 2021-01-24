    //This function returns a point which is a projection from a point to a line.
    //The line is regarded infinite. If the line is finite, use ProjectPointOnLineSegment() instead.
    public static Vector3 ProjectPointOnLine(Vector3 linePoint, Vector3 lineVec, Vector3 point)
    {
    
    	//get vector from point on line to point in space
    	Vector3 linePointToPoint = point - linePoint;
    
    	float t = Vector3.Dot(linePointToPoint, lineVec);
    
    	return linePoint + lineVec * t;
    }
