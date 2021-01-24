        Mat orig = new Mat(@"C:\Users\Public\Pictures\Sample Pictures\Koala.jpg", ImreadModes.Color);
        using (Mat hsv = new Mat())
        {
            CvInvoke.CvtColor(orig, hsv, ColorConversion.Bgr2Hsv);
            Mat[] channels = hsv.Split();
            RangeF H = channels[0].GetValueRange();
            RangeF S = channels[1].GetValueRange();
            RangeF V = channels[2].GetValueRange();
            Console.WriteLine(string.Format("Max H {0} Min H {1}", H.Max, H.Min));
            Console.WriteLine(string.Format("Max S {0} Min S {1}", S.Max, S.Min));
            Console.WriteLine(string.Format("Max V {0} Min V {1}", V.Max, V.Min));
            MCvScalar mean = CvInvoke.Mean(hsv);
            Console.WriteLine(string.Format("Mean V {0} Mean S {1} Mean V {2} ", mean.V0, mean.V1, mean.V2)); ;
        }
