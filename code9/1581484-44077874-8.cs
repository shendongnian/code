    public static List<List<ISegment>>GetSegmentChains(List<ISegment> segments)
    {
        // Some quick 'fail fast' validation
        var segmentChains = new List<List<ISegment>>();
        if (segments == null) return segmentChains;
        if (segments.Count == 0) return segmentChains;
        if (segments.Count == 1)
        {
            if (IsSingleSegmentChain(segments[0])) segmentChains.Add(segments);
            return segmentChains;
        }
        // Get a copy of our segments
        var candidateSegments = segments.ToList();
        // Process each one
        while (candidateSegments.Any())
        {
            // Remove the first one from the candidate list and add it to a temporary chain
            // list, and add it's endPoints to a list for comparision with other candidates
            var candidateSegment = candidateSegments.First();
            candidateSegments.Remove(candidateSegment);
            var candidateChain = new List<ISegment> { candidateSegment };
            var endPoints = new List<Point3D> {candidateSegment.A, candidateSegment.B};
            // Go through the points list, finding any candidates with a match
            while (endPoints.Any())
            {
                foreach (var endPoint in endPoints.ToList())
                {
                    // Add the 'other' point to our points list from each 
                    // candidate that has a match with this point
                    foreach (var candidate in candidateSegments.Where(c => c.A == endPoint)
                        .ToList())
                    {
                        endPoints.Add(candidate.B);
                        candidateSegments.Remove(candidate);
                        candidateChain.Add(candidate);
                    }
                    foreach (var candidate in candidateSegments.Where(c => c.B == endPoint)
                        .ToList())
                    {
                        endPoints.Add(candidate.A);
                        candidateSegments.Remove(candidate);
                        candidateChain.Add(candidate);
                    }
                    // Remove this point since it's been fully processed
                    endPoints.Remove(endPoint);
                }
            }
            // See if we have a chain, and if so, add it to our return list
            if (candidateChain.Count == 1 && IsSingleSegmentChain(candidateChain[0]) ||
                candidateChain.Count > 1)
            {
                segmentChains.Add(candidateChain);
            }
        }
        return segmentChains;
    }
