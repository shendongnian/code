    byte[,] a = new byte[7, 6]
    {
        { 0, 1, 1, 1, 0, 0 },
        { 0, 1, 0, 1, 0, 0 },
        { 0, 1, 1, 1, 0, 0 },
        { 0, 0, 0, 0, 0, 0 },
        { 0, 1, 1, 1, 1, 1 },
        { 0, 1, 0, 1, 0, 1 },
        { 0, 1, 1, 1, 1, 1 }
    };
    // Clone matrix if you want to keep original array unmodified.
    using (var mat = new MatOfByte(a.GetLength(0), a.GetLength(1), a).Clone())
    {
        // Turn 1 pixel values into 255.
        Cv2.Threshold(mat, mat, thresh: 0, maxval: 255, type: ThresholdTypes.Binary);
        // Note that in OpenCV Point.X is a matrix column index and Point.Y is a row index.
        Point[][] contours;
        HierarchyIndex[] hierarchy;
        Cv2.FindContours(mat, out contours, out hierarchy, RetrievalModes.CComp, ContourApproximationModes.ApproxNone);
        for (var i = 0; i < contours.Length; ++i)
        {
            var hasHole = hierarchy[i].Child > -1;
            if (hasHole)
            {
                var externalContour = contours[i];
                // Process external contour.
                var holeIndex = hierarchy[i].Child;
                do
                {
                    var hole = contours[holeIndex];
                    // Process hole.
                    holeIndex = hierarchy[holeIndex].Next;
                }
                while (holeIndex > -1);
            }
        }
    }
