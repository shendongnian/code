    class BitmapContainer : IDisposable
    {
        Bitmap Value {get; private set;}
        string OriginalLocation {get; private set;}
        public BitmapContainer(string sourceImage) 
        {
            Value = new Bitmap(sourceImage);
            OriginalLocation = sourceImage;
            //you get the picture
        }
        //Don't forget to implement a dispose pattern because Bitmap uses native resources
    }
