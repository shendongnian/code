    public static string ReadStringFromStream( Stream stream )
    {
        // --- Byte-oriented state ---
        // A nice big buffer for us to use to read from the stream.
        byte[] byteBuffer = new byte[8192];
        // --- Char-oriented state ---
        // Gets a stateful UTF8 decoder that holds onto unused bytes when multi-byte sequences
        // are split across multiple byte buffers.
        var decoder = Encoding.UTF8.GetDecoder();
            
        // Initialize a char buffer, and make it large enough that it will be able to fit
        // a full reads-worth of data from the byte buffer without needing to be resized.
        char[] charBuffer = new char[Encoding.UTF8.GetMaxCharCount( byteBuffer.Length )];
        // --- Output ---
        StringBuilder stringBuilder = new StringBuilder();
        // --- Working state ---
        int bytesRead;
        int charsConverted;
        bool lastRead = false;
        do
        {
            // Read a chunk of bytes from our stream.
            bytesRead = stream.Read( byteBuffer, 0, byteBuffer.Length );
            // If we read 0 bytes, we hit the end of stream.
            // We're going to tell the converter to flush, and then we're going to stop.
            lastRead = ( bytesRead == 0 );
            // Convert the bytes into characters, flushing if this is our last conversion.
            charsConverted = decoder.GetChars( 
                byteBuffer, 
                0, 
                bytesRead, 
                charBuffer, 
                0, 
                lastRead 
            );
            // Build up a string in a character buffer.
            stringBuilder.Append( charBuffer, 0, charsConverted );
        }
        while( lastRead == false );
        return stringBuilder.ToString();
    }
