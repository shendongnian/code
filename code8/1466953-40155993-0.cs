            Bitmap bitmap = (Bitmap)this.PictureBoxOriginalBitmap.Image;
            var width = bitmap.Width;
            var height = bitmap.Height;
            var shiftEnumerable = Enumerable.Range(0, 8).Reverse(); // create an array from (7..0) MSB as the first
            var dataList = new List<byte>(); // Create a list instead of fiddeling with array indexes
            for (int rowIndex = 7; rowIndex < height; rowIndex=rowIndex+8 ) // increment 8 pixels each iteration on y-axis. If picture is less than 8 pixels, convertion will not happen.
            {
                for (int columnIndex = 0; columnIndex < width; columnIndex++) // increment x-axis
                {
                    // Linq which performs a bitwise OR operation. Converts the predicate to byte and shifts result x places depending on which bit needs to be set.
                    // Add the accumulated OR operation to a list of bytes.
                    dataList.Add(shiftEnumerable.Aggregate<int, byte>(
                        0,
                        (accumulate, current) => (byte)(accumulate | (byte)(Convert.ToByte(bitmap.GetPixel(columnIndex, rowIndex - current).R == 255) << current))));
                }
            }
            // Convert List to array.
            var data = dataList.ToArray();
