        /// <summary>
        /// Create tfw - world file.
        /// </summary>
        /// <param name="filename">tif image full filename</param>
        private void CreateWorldFile(string filename)
        {
            using (var bitmapImage = new Bitmap(filename))
            {
                PropertyItem[] imageProps = bitmapImage.PropertyItems;
                var modelscale = imageProps.First(a => a.Id == GEOTIFF_MODELPIXELSCALETAG);
                var tiepoint = imageProps.First(a => a.Id == GEOTIFF_MODELTIEPOINTTAG);
                double x = BitConverter.ToDouble(tiepoint.Value, 0 + 24);
                double y = BitConverter.ToDouble(tiepoint.Value, 0 + 32);
                double xscale = BitConverter.ToDouble(modelscale.Value, 0);
                double yscale = BitConverter.ToDouble(modelscale.Value, 0 + 8);
                string tfwFileName = Path.GetDirectoryName(filename) + "\\" + Path.GetFileNameWithoutExtension(filename) + ".tfw";
                using (System.IO.StreamWriter file = new System.IO.StreamWriter(tfwFileName))
                {
                    file.WriteLine(xscale);
                    file.WriteLine("0.0");
                    file.WriteLine("0.0");
                    file.WriteLine(yscale);
                    file.WriteLine(x);
                    file.WriteLine(y);
                }
            }
        }
        private readonly int GEOTIFF_MODELPIXELSCALETAG = 33550;
        private readonly int GEOTIFF_MODELTIEPOINTTAG = 33922;
