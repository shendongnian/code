        private void brightThumb(string input, string output, double time, int getNewFrame, bool goBack)
        {
            //get initial thumbnail
            this.ffmpegGetThumb(input, output, time);
            Bitmap frame = this.ConvertToBitmap(output);
            double brightness = CalculateAverageLightness(frame);
            double newTime = time;
            if (CalculateAverageLightness(frame) < 0.1)
            {
                // brightness is to low
                // get a new thumbnail by increasing the time at which it's taken
                if (getNewFrame == 1 && goBack == false)
                {
                    newTime = time + 1000;
                }
                // if goBack is true (the time is beyond a third of the total duration)
                // we decrease the time (if curent time is at credits no point going forward)
                else if (getNewFrame == 1 && goBack == true)
                {
                    newTime = time - 1000;
                }
                // take a new thumbnail at the adujted time
                this.brightThumb(input, output, newTime, 1, goBack);
            }
        }
