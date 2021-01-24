        public static bool MatchElementwiseThreshold<T>(ReadOnlySpan<T> x1, ReadOnlySpan<T> x2, T threshold)
            where T : struct
        {
            if (x1.Length != x2.Length)
                throw new ArgumentException("x1.Length != x2.Length");
            if (Vector.IsHardwareAccelerated)
            {
                var vx1 = x1.NonPortableCast<T, Vector<T>>();
                var vx2 = x2.NonPortableCast<T, Vector<T>>();
                var vthreshold = new Vector<T>(threshold);
                for (int i = 0; i < vx1.Length; ++i)
                {
                    var v1cmp = Vector.GreaterThan(vx1[i], vthreshold);
                    var v2cmp = Vector.GreaterThan(vx2[i], vthreshold);
                    if (Vector.AsVectorInt32(Vector.Xor(v1cmp, v2cmp)) != Vector<int>.Zero)
                        return false;
                }
                // slice them to handling remaining elementss
                x1 = x1.Slice(Vector<T>.Count * vx1.Length);
                x2 = x2.Slice(Vector<T>.Count * vx1.Length);
            }
            var comparer = System.Collections.Generic.Comparer<T>.Default;
            for (int i = 0; i < x1.Length; i++)
                if ((comparer.Compare(x1[i], threshold) > 0) != (comparer.Compare(x2[i], threshold) > 0))
                    return false;
            return true;
        }
