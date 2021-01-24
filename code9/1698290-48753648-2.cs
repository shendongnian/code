    class Program
    {
        static float calcBlurriness(Mat src)
        {
            Mat Gx = new Mat();
            Mat Gy = new Mat();
            Cv2.Sobel(src, Gx, MatType.CV_32F, 1, 0);
            Cv2.Sobel(src, Gy, MatType.CV_32F, 0, 1);
            double normGx = Cv2.Norm(Gx);
            double normGy = Cv2.Norm(Gy);
            double sumSq = normGx * normGx + normGy * normGy;
            return (float)(1.0 / (sumSq / (src.Size().Height * src.Size().Width) + 1e-6));
        }
        static void Main(string[] args)
        {
            Mat src = Cv2.ImRead("lenna.png", ImreadModes.GrayScale);
            Mat dst = new Mat();
            var blurIndex = calcBlurriness(src);
            //test: find edges...
            //Cv2.Canny(src, dst, 50, 200);
            //using (new Window("src image", src))
            //using (new Window("dst image", dst))
            //{Cv2.WaitKey();}
        }
    }
