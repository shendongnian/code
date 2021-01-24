        using Emgu.CV;
        using System.Drawing.Imaging;
        private VideoQuality quality;
        private ImageCodecInfo codecInfo;
        private EncoderParameters encoderParameters;
        public byte[] compress(Mat image) {
            using(MemoryStream memstream = new MemoryStream()) {
                long tstart = Toolkit.CurrentTimeMillis();
                image.Bitmap.Save(memstream, codecInfo, encoderParameters);
                return memstream.ToArray();
            }
        }
        private void setVideoQuality(long quality) {
            this.codecInfo = getEncoder(ImageFormat.Jpeg);
            this.encoderParameters = new EncoderParameters(1);
            encoderParameters.Param[0] = new EncoderParameter(Encoder.Quality, quality);
        }
        private ImageCodecInfo getEncoder(ImageFormat format) {
            ImageCodecInfo[] codecs = ImageCodecInfo.GetImageDecoders();
            foreach(ImageCodecInfo codec in codecs) {
                if(codec.FormatID == format.Guid) {
                    return codec;
                }
            }
            return null;
        }
