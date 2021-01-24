    public static bool MatchElementwiseThresholdSIMD(ReadOnlySpan<float> x1, ReadOnlySpan<float> x2, float threshold)
    {
        if (x1.Length != x2.Length) throw new ArgumentException("x1.Length != x2.Length");
        if (Vector.IsHardwareAccelerated)
        {
            var vx1 = x1.NonPortableCast<float, Vector<float>>();
            var vx2 = x2.NonPortableCast<float, Vector<float>>();
            var vthreshold = new Vector<float>(threshold);
            for (int i = 0; i < vx1.Length; ++i)
            {
                var v1cmp = Vector.GreaterThan(vx1[i], vthreshold);
                var v2cmp = Vector.GreaterThan(vx2[i], vthreshold);
                if (Vector.Xor(v1cmp, v2cmp) != Vector<int>.Zero)
                    return false;
            }
            x1 = x1.Slice(Vector<float>.Count * vx1.Length);
            x2 = x2.Slice(Vector<float>.Count * vx1.Length);
        }
        for (var i = 0; i < x1.Length; i++)
            if (x1[i] > threshold != x2[i] > threshold)
                return false;
        return true;
    }
