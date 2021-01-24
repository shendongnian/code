    public static Rect ObjectBounds(GameObject go)
        {
            Vector3 cen = go.GetComponent<Renderer>().bounds.center;
            Vector3 ext = go.GetComponent<Renderer>().bounds.extents;
            Vector2[] extentPoints = new Vector2[8]
            {
             HandleUtility.WorldToGUIPoint(new Vector3(cen.x-ext.x, cen.y-ext.y, cen.z-ext.z)),
             HandleUtility.WorldToGUIPoint(new Vector3(cen.x+ext.x, cen.y-ext.y, cen.z-ext.z)),
             HandleUtility.WorldToGUIPoint(new Vector3(cen.x-ext.x, cen.y-ext.y, cen.z+ext.z)),
             HandleUtility.WorldToGUIPoint(new Vector3(cen.x+ext.x, cen.y-ext.y, cen.z+ext.z)),
             HandleUtility.WorldToGUIPoint(new Vector3(cen.x-ext.x, cen.y+ext.y, cen.z-ext.z)),
             HandleUtility.WorldToGUIPoint(new Vector3(cen.x+ext.x, cen.y+ext.y, cen.z-ext.z)),
             HandleUtility.WorldToGUIPoint(new Vector3(cen.x-ext.x, cen.y+ext.y, cen.z+ext.z)),
             HandleUtility.WorldToGUIPoint(new Vector3(cen.x+ext.x, cen.y+ext.y, cen.z+ext.z))
            };
            Vector2 min = extentPoints[0];
            Vector2 max = extentPoints[0];
            foreach (Vector2 v in extentPoints)
            {
                min = Vector2.Min(min, v);
                max = Vector2.Max(max, v);
            }
            return new Rect(min.x, min.y, max.x - min.x, max.y - min.y);
        }
