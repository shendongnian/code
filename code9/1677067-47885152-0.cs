    public static IEnumerable<Tuple<PointF, PointF>> ClipSegment(RectangleF r, PointF p1, PointF p2)
    {
        // classify the endpoints of the line
        var outCodeP1 = ComputeOutCode(p1, r);
        var outCodeP2 = ComputeOutCode(p2, r);
        var results = new List<Tuple<PointF,PointF>>();
        while (true)
        { 
            // Case 1:
           // both endpoints are within the clipping region
            if ((outCodeP1 | outCodeP2) == OutCode.Inside)
            {
                //Completely clipped
                break;
            }
            // Case 2:
            // both endpoints share an excluded region, impossible for a line between them to be within the clipping region
            if ((outCodeP1 & outCodeP2) != 0)
            {
                //Not clipped at all
                results.Add(Tuple.Create(p1,p2));                    
                break;
            }
            //Case 3: The endpoints are in different regions, and the segment is partially within
            //the clipping rectangle Select one of the endpoints outside the clipping rectangle
            var outCode = outCodeP1 != OutCode.Inside ? outCodeP1 : outCodeP2; 
            // calculate the intersection of the line with the clipping rectangle using parametric line equations
            var p = CalculateIntersection(r, p1, p2, outCode);
            // update the point after clipping and recalculate outcode
            if (outCode==outCodeP1)
            {
                //Keep "discarded" segment
                results.Add(Tuple.Create(p1,p));
                p1 = p;
                outCodeP1 = ComputeOutCode(p1, r);
            }
            else
            {
                //ditto
                results.Add(Tuple.Create(p,p2));
                p2 = p;
                outCodeP2 = ComputeOutCode(p2, r);
            }
        }
        return results;
    }       
