    class BigDataStream : Stream
    {
        public BigDataStream()
        {
            // open DB connection
            // run your query
            // get a DataReader
        }
        // you need a buffer to encode your data between calls to Read
        List<byte> _encodeBuffer = new List<byte>();
        public override int Read(byte[] buffer, int offset, int count)
        {
            // read from the DataReader and populate the _encodeBuffer
            // until the _encodeBuffer contains at least count bytes
            // (or until there are no more records)
            // for example:
            while (_encodeBuffer.Count < count && _reader.Read())
            {
                // (1)
                // encode the record into a byte array. How to do this?
                // you can read into a class and then use the data 
                // contract serialization for example. If you do this, you
                // will probably find it easier to prepend an integer which
                // specifies the length of the following encoded message. 
                // This will make it easier for the client to deserialize it.
                // (2)
                // append the encoded record bytes (plus any length prefix 
                // etc) to _encodeBuffer
            }
            // remove up to the first count bytes from _encodeBuffer
            // and copy them into buffer at the offset requested
            // return the number of bytes added
        }
        public override void Close()
        {
            // close the reader + db connection
            base.Close();
        }
    }
