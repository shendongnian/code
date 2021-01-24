    Point[] points;
    using (var ms = new MemoryStream(data)) {
        using (var r = new BinaryReader(ms)) {
            int len = r.ReadInt32();
            points = new Point[len];
            for (int i = 0 ; i != len ; i++) {
                points[i] = new Point(r.ReadInt32(), r.ReadInt32());
            }
        }
    }
