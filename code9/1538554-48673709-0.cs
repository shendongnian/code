        public async Task<BitmapImage> MyBitmapAsync(byte[] value)
        {
            if (value == null || !(value is byte[]))
                return null;
            using (InMemoryRandomAccessStream ms = new InMemoryRandomAccessStream())
            {
                using (DataWriter writer = new DataWriter(ms.GetOutputStreamAt(0)))
                {
                    writer.WriteBytes((byte[])value);
                    writer.StoreAsync().GetResults();
                }
                var image = new BitmapImage();
                image.SetSource(ms);
                return image;
            }
        }
