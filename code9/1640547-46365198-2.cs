    public static class CameraEx
    {
        public static bool IsObjectVisible(this UnityEngine.Camera @this, Renderer renderer)
        {
    	    return GeometryUtility.TestPlanesAABB(GeometryUtility.CalculateFrustumPlanes(@this), renderer.bounds);
        }
    }
