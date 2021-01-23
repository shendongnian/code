        /// <summary>
        /// Checks if there are boundaryreps that are marked as elliptical or circular arcs
        /// returns true if we found at least 2 of those points
        /// also stores the points in a referenced Point3dCollection
        /// </summary>
        /// <param name="solid"></param>
        /// <param name="pts"></param>
        /// <returns></returns>
        private bool GetSweepPathPoints(Solid3d solid, ref Point3dCollection pts)
        {
            // create boundary rep for the solid
            using (Brep brep = new Brep(solid))
            {
                // get edges of the boundary rep
                BrepEdgeCollection edges = brep.Edges;
                foreach (Edge edge in edges)
                {
                    // get the nativ curve geometry of the edges and then 
                    // check if it is a circle
                    // for more info look at:
                    // http://adndevblog.typepad.com/autocad/2012/08/retrieving-native-curve-geometry-using-brep-api.html
                    Curve3d curv = ((ExternalCurve3d)edge.Curve).NativeCurve;
                    if (curv is CircularArc3d)
                    {
                        // transform curved arch into circle and add it to the colecction 
                        // (if not in it alreadz)
                        CircularArc3d circle = curv as CircularArc3d;
                        if (!pts.Contains(circle.Center)) pts.Add(circle.Center);
                    }
                }
            }
            return (pts.Count > 1) ? true : false;
        }
