    class binaryTranslate
    {
        public enum IncompleteSegmentBehavior
        {
            Skip = 0,
            ZerosToStart = 1,
            ZerosToEnd = 2
        }
        private byte ConvertBinstrToByte(string sequence)
        {
            if (string.IsNullOrEmpty(sequence))
                return 0; // Throw?
            if (sequence.Length != sizeof(byte) * 8)
                return 0; // Throw?
            const char zero = '0';
            const char one = '1';
            byte value = 0;
            for (int i = 0; i < sequence.Length; i++)
            {
                if (sequence[i] != zero && sequence[i] != one)
                    return 0; // Throw
                value |= (byte)((sequence[i] - zero) << (7 - i));
            }
            return value;
        }
        private string HandleIncompleteSegment(string segment, int segmentSize, IncompleteSegmentBehavior behavior)
        {
            string result = null;
            var zeroAppender = new StringBuilder();
            for (int i = 0; i < segmentSize - segment.Length; i++)
                zeroAppender.Append('0');
            var zeros = zeroAppender.ToString();
            switch (behavior)
            {
                case IncompleteSegmentBehavior.Skip:
                    break;
                case IncompleteSegmentBehavior.ZerosToStart:
                    result = zeros + result;
                    break;
                case IncompleteSegmentBehavior.ZerosToEnd:
                    result = result + zeros;
                    break;
                default:
                    break;
            }
            return result;
        }
        public byte[] ConvertBinstrToBytes(string binarySequence, IncompleteSegmentBehavior behavior = IncompleteSegmentBehavior.Skip)
        {
            var segmentSize = sizeof(byte) * 8;
            var sequenceLength = binarySequence.Length;
            var numberOfBytes = (int)Math.Ceiling((double)sequenceLength / segmentSize);
            var bytes = new byte[numberOfBytes];
                
            for (int i = 0; i < numberOfBytes; i++)
            {
                var charactersLeft = sequenceLength - i * segmentSize;
                var segmentLength = (charactersLeft < segmentSize ? charactersLeft : segmentSize);
                var segment = binarySequence.Substring(i * segmentSize, segmentLength);
                if (charactersLeft < segmentSize)
                {
                    segment = HandleIncompleteSegment(segment, segmentSize, behavior);
                    if (segment == null)
                        continue;
                }
                bytes[i] = ConvertBinstrToByte(segment);
            }
            return bytes;
        }
    }
