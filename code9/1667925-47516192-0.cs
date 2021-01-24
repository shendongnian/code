    using System;
    using System.Drawing;
    public static class RegionExtension
    {
        public static bool Contains(this Region thisRegion, Region r)
        {
            using (var thisClone = thisRegion.Clone())
            {
                using (var g = Graphics.FromHwnd(IntPtr.Zero))
                {
                    thisClone.Intersect(r);
                    return thisClone.Equals(r, g);
                }
            }
        }
    }
