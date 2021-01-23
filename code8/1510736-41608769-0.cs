        private void WavOutChartTimeInterrupt(object waveReader)
    {
        lock (AudioLock) //todo add skipto code, use audio lock to do it.
        {
            try
            {
                var curPos = _waveOut.GetPositionTimeSpan(); //get currentPos
                if (curPos <= AudioCurrentPosition)
                {
                    AudioCurrentPosition = curPos;
                    return;
                }
                var bufferLength = (curPos - AudioCurrentPosition);
                var samplesSec = _waveOutSampleProvider.WaveFormat.SampleRate;
                var channels = _waveOut.OutputWaveFormat.Channels;
                var length = (int) (bufferLength.TotalSeconds * samplesSec * channels) % (samplesSec * channels);
                length -= length% (blockAlign / channels);  //<- THIS FIXED IT
                var wavOutBuffer = new float[length];
                _waveOutSampleProvider.Read(wavOutBuffer, 0, length);
                AudioCurrentPosition = curPos; //update for vCNC with where we are
            }
            catch (Exception e)
            {
                string WTF = e.StackTrace;
                throw new ArgumentException(@"Wave out buffer crashed" + e.StackTrace.ToString());
            }
        }
