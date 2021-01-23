                Point3dCollection pts = new Point3dCollection();
                // only do the whole thing if we face a swept solid
                if (GetSweepPathPoints(sld, ref pts))
                {
                    for (int i = 0; i < pts.Count; i++)
                    {
                        ed.WriteMessage("\nPt[{0}] = {1}", i, pts[i]);
                    }
                }
