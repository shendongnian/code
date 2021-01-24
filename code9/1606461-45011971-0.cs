    public static T[] GetNGonCenters<T>(this Mesh mesh) where T : Point3d
    {
        T[] centers = new T[mesh.Ngons.Count];
        for (int i = 0; i < mesh.Ngons.Count; i++)
            centers[i] = (T)mesh.Ngons.GetNgonCenter(i);
        return centers;
    }
