        WaveOut waveOut;
        AcmMp3FrameDecompressor decompressor;
        BufferedWaveProvider provider;
        bool firstPlay = true;
        public void Play()
        {
            Task.Run(() =>
            {
                #region WebRequest creator
                HttpWebResponse response = null;
                if (avgbytes < 0)
                {
                    HttpWebRequest req = WebRequest.Create(url) as HttpWebRequest;
                    req.AllowAutoRedirect = true;
                    req.UserAgent = "Mozilla/5.0 (Windows NT 6.3; WOW64; rv:31.0) Gecko/20100101 Firefox/31.0";
                    response = req.GetResponse() as HttpWebResponse;
                    contentLength = response.ContentLength;
                }
                else
                    response = Helper.CreateAudioWebRequest(url, currentTime, avgbytes)
                                     .GetResponse() as HttpWebResponse;
                Stream responseStream = response.GetResponseStream();
                #endregion
                #region Local Variables
                byte[] buffer = new byte[17 * 1024];
                byte[] bigBuffer = new byte[response.ContentLength];
                int bytesRead = 0;
                long pos = 0;
                long postotal = 0;
                string path = System.IO.Path.GetTempPath() + Guid.NewGuid().ToString() + ".mp3";
                #endregion
                Mp3Frame frame;
                FileStream fs = new FileStream(path,
                    FileMode.Create, FileAccess.ReadWrite, FileShare.ReadWrite);
                do
                {
                    bytesRead = responseStream.Read(buffer, 0, buffer.Length);
                    fs.Write(buffer, 0, bytesRead);
                    fs.Flush();
                    using (MemoryStream ms = new MemoryStream(ReadPartial(fs, postotal, 1024 * 10)))
                    {
                        ms.Position = 0;
                        frame = Mp3Frame.LoadFromStream(ms);
                        if (frame == null)
                        {
                            continue;
                        }
                        pos = ms.Position;
                        postotal += pos;
                    }
                    #region First Play
                    if (firstPlay)
                    {
                        avgbytes = new Mp3WaveFormat(frame.SampleRate, frame.ChannelMode == ChannelMode.Mono ? 1 : 2,
                    frame.FrameLength, frame.BitRate).AverageBytesPerSecond;
                        duration = (int)(response.ContentLength * 1d / avgbytes);
                        firstPlay = false;
                    }
                    #endregion
                    #region Decompress Frame
                    if (decompressor == null)
                    {
                        decompressor = CreateFrameDecompressor(frame) as AcmMp3FrameDecompressor;
                        provider = new BufferedWaveProvider(decompressor.OutputFormat);
                        provider.BufferDuration = TimeSpan.FromSeconds(20);
                    }
                    int decompressed = decompressor.DecompressFrame(frame, buffer, 0);
                    #endregion
                    #region BufferedWaveProvider Area
                    if (IsBufferNearlyFull(provider))
                    {
                        Thread.Sleep(500);
                    }
                    provider.AddSamples(buffer, 0, decompressed);
                    #endregion
                    if (provider.BufferedDuration.TotalSeconds >= 2 && waveOut == null)
                    {
                        waveOut = new WaveOut();
                        waveOut.Init(provider);
                        waveOut.Play();
                    }
                }
                while (postotal != contentLength || bytesRead > 0 || waveOut==null || 
                            (waveOut != null && waveOut.PlaybackState == PlaybackState.Playing));
            });
        }
        public static byte[] ReadStreamPartially(System.IO.Stream stream, long offset, long count)
        {
            long originalPosition = 0;
            if (stream.CanSeek)
            {
                originalPosition = stream.Position;
                stream.Position = offset;
            }
            try
            {
                byte[] readBuffer = new byte[4096];
                byte[] total = new byte[count];
                int totalBytesRead = 0;
                int byteRead;
                while ((byteRead = stream.ReadByte()) != -1)
                {
                    Buffer.SetByte(total, totalBytesRead, (byte)byteRead);
                    totalBytesRead++;
                    if (totalBytesRead == count)
                    {
                        stream.Position = originalPosition;
                        break;
                    }
                }
                if (totalBytesRead < count)
                {
                    byte[] temp = new byte[totalBytesRead];
                    Buffer.BlockCopy(total, 0, temp, 0, totalBytesRead);
                    stream.Position = originalPosition;
                    return temp;
                }
                return total;
            }
            finally
            {
                if (stream.CanSeek)
                {
                    stream.Position = originalPosition;
                }
            }
        }
        private bool IsBufferNearlyFull(BufferedWaveProvider bufferedWaveProvider)
        {
            return bufferedWaveProvider != null &&
                   bufferedWaveProvider.BufferLength - bufferedWaveProvider.BufferedBytes
                   < bufferedWaveProvider.WaveFormat.AverageBytesPerSecond / 4;
        }
        private static IMp3FrameDecompressor CreateFrameDecompressor(Mp3Frame frame)
        {
            WaveFormat waveFormat = new Mp3WaveFormat(frame.SampleRate, frame.ChannelMode == ChannelMode.Mono ? 1 : 2,
                frame.FrameLength, frame.BitRate);
            return new AcmMp3FrameDecompressor(waveFormat);
        }
