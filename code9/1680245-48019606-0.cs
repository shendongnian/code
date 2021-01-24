    public object Convert(object value,Type targetType,object parameter,CultureInfo cultureInfo)
    {
        try
        {
            if (value is Tuple<Tuple<int, int, int, int>, string>)
            {
                Tuple<Tuple<int, int, int, int>, string> tuple = value as Tuple<Tuple<int, int, int, int>, string>;
                Tuple<int, int, int, int> rectDims = tuple.Item1;
                string filePath = tuple.Item2;
                using (MyDocument doc = MyDocument.Load(filePath))
                {
                    var size = doc.Size;
                    int width = (int)(size.Width);
                    int height = (int)(size.Height);
                    Rectangle cropSection = new Rectangle(rectDims.Item1, rectDims.Item3, Math.Abs(rectDims.Item1 - rectDims.Item2), Math.Abs(rectDims.Item3 - rectDims.Item4));
                    using (Image image = doc.Render(0, width, height, 300, 300, false))
                    {
                        BitmapSource sourceImage = BitmapHelper.ToBitmapSource(image);
    					CroppedBitmap croppedImage = new CroppedBitmap(sourceImage,new System.Windows.Int32Rect(cropSection.X,cropSection.Y,cropSection.Width,cropSection.Height));
    					return croppedImage;
                    }
                }
            }
            else
            {
                return null;
            }
        }
        catch (Exception ex)
        {
            return null;
        }
    }
