    public class ImageProcessor
    {
        bool bProcessing;
        private void getPoints() { }
        public Action DoImageProcessing;
        public ImageProcessor()
        {
            DoImageProcessing = () =>
            {
                bProcessing = true;
                getPoints();
                bProcessing = false;
            };
        }
     }
