    public class BinaryFinder
    {
        private readonly long _packagesCount;
        private readonly FileStream _reader;
        public BinaryFinder(FileStream reader, int packageSize)
        {
            _reader = reader;
            _packagesCount = reader.Length / packageSize;
        }
        public long Find(DateTime dateToSearch)
        {
            return Find(0, _packagesCount, dateToSearch);
        }
        private long Find(long minPosition, long maxPosition, DateTime dateToSearch)
        {
            while (minPosition<=maxPosition) {
                var newPosition = (minPosition + maxPosition) / 2;
                var readDate = ReadDateAt(newPosition);
                if (readDate == dateToSearch) {
                    return newPosition;
                }
                
                if (dateToSearch < readDate){
                    maxPosition = newPosition-1;
                }
                else {
                    minPosition = newPosition+1;
                }
            }
            return -1;
        }
        private DateTime ReadDateAt(long middlePosition)
        {
            var buffer = new byte[8];
            _reader.Seek(middlePosition, SeekOrigin.Begin);
            _reader.Read(buffer, 0, buffer.Length);
            var currentDate = ConvertBytesToDate(buffer);
            return currentDate;
        }
        private static DateTime ConvertBytesToDate(byte[] dateBytes)
        {
            throw new NotImplementedException();
        }
    }
