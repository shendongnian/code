    using (var src = new Mat(filePath))
    using (var gray = new Mat())
    {
        using (var bw = src.CvtColor(ColorConversionCodes.BGR2GRAY)) // convert to grayscale
        {
            // invert b&w (specific to your white on black image)
            Cv2.BitwiseNot(bw, gray);
        }
        // find all contours
        var contours = gray.FindContoursAsArray(RetrievalModes.List, ContourApproximationModes.ApproxSimple);
        using (var dst = src.Clone())
        {
            foreach (var contour in contours)
            {
                // filter small contours by their area
                var area = Cv2.ContourArea(contour);
                if (area < 15 * 15) // a rect of 15x15, or whatever you see fit
                    continue;
                // also filter the whole image contour (by 1% close to the real area), there may be smarter ways...
                if (Math.Abs((area - (src.Width * src.Height)) / area) < 0.01f)
                    continue;
                var hull = Cv2.ConvexHull(contour);
                Cv2.Polylines(dst, new[] { hull }, true, Scalar.Red, 2);
            }
            using (new Window("src image", src))
            using (new Window("dst image", dst))
            {
                Cv2.WaitKey();
            }
        }
    }
