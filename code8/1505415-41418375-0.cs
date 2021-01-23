    public class TextMasker
    {
        private readonly int _bufferSize;
        private readonly string _outputDataPath;
        private readonly byte _maskByte;
        private readonly byte[] _unmaskableBytes;
        
        public TextMasker()
        {
            _bufferSize = 4096;
            _outputDataPath = "outputData.txt";
            _maskByte = Encoding.UTF8.GetBytes("*")[0];
            _unmaskableBytes = Encoding.UTF8.GetBytes(" ,.");
        }
        public void Mask(MemoryStream inputData, int unmaskedStart, int unmaskedStop)
        {
            var byteIndex = 0;
            var buffer = new byte[_bufferSize];
            using (var fileStream = File.OpenWrite(_outputDataPath))
            {
                int bytesBuffered;
                while ((bytesBuffered = inputData.Read(buffer, 0, buffer.Length)) != 0)
                {
                    for (var i = 0; i < bytesBuffered; i++, byteIndex++)
                    {
                        if ((byteIndex < unmaskedStart - 1 || byteIndex > unmaskedStop - 1)
                            && !_unmaskableBytes.Contains(buffer[i]))
                        {
                            buffer[i] = _maskByte;
                        }
                    }
                    fileStream.Write(buffer, 0, bytesBuffered);
                }
            }
        }
    }
