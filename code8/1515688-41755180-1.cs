        private void Capture()
        {
            Nequeo.Media.FFmpeg.MediaDemux demux = new Nequeo.Media.FFmpeg.MediaDemux();
            demux.OpenDevice("video=Integrated Webcam", true, false);
            // create instance of video writer
            Nequeo.Media.FFmpeg.VideoFileWriter writer = new Nequeo.Media.FFmpeg.VideoFileWriter();
            writer.Open(@"C:\Temp\Misc\ffmpeg_screen_capture_video.avi", demux.Width, demux.Height, demux.FrameRate, Nequeo.Media.FFmpeg.VideoCodec.MPEG4);
            byte[] sound = null;
            Bitmap[] image = null;
            List<Bitmap> video = new List<Bitmap>();
            long audioPos = 0;
            long videoPos = 0;
            int captureCount = 0;
            int captureNumber = 500;
            while ((demux.ReadFrame(out sound, out image, out audioPos, out videoPos) > 0) && captureCount < captureNumber)
            {
                if (image != null && image.Length > 0)
                {
                    captureCount++;
                    for (int i = 0; i < image.Length; i++)
                    {
                        writer.WriteVideoFrame(image[i]);
                        image[i].Dispose();
                    }
                }
            }
            writer.Close();
            demux.Close();
        }
