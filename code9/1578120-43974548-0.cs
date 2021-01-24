            StorageFolder sharedFonts = Windows.Storage.ApplicationData.Current.GetPublisherCacheFolder("test");
            var testFile = await sharedFonts.CreateFileAsync("test.txt", CreationCollisionOption.OpenIfExists);
            var byteArray = new byte[] { 0x61, 0x62, 0x63, 0x64, 0x65, 0x66, 0x67, 0x68, 0x69, 0x6a };
            using (var sourceStream = new MemoryStream(byteArray).AsRandomAccessStream())
            {
                using (var destinationStream = (await testFile.OpenAsync(FileAccessMode.ReadWrite)).GetOutputStreamAt(0))
                {
                    await RandomAccessStream.CopyAndCloseAsync(sourceStream, destinationStream);
                }
            }
            var readArray = new byte[100];
            using (var destinationStream = new MemoryStream(readArray).AsRandomAccessStream())
            {
                using (var sourceStream = (await testFile.OpenAsync(FileAccessMode.Read)).GetInputStreamAt(0))
                {
                    await RandomAccessStream.CopyAndCloseAsync(sourceStream, destinationStream);
                }
            }
