        using (WordprocessingDocument wordDoc = WordprocessingDocument.Open(byteArrayOriginalStream, true))
        {
            //...
        }
        byteArrayOriginalStream.Seek(0, SeekOrigin.Begin);
        byteArrayOriginalStream.CopyTo(outputStream);
