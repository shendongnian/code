    public void WaitFor( byte[ ] buffer )
    {
        if ( buffer.Length == 0 )
            return;
        var q = new List<byte>( buffer.Length );
        while ( true )
        {
            var current = _reader.ReadByte();
            q.Add( (byte)current );
            // sequence match so far
            if ( q.Last == buffer[ q.Count - 1 ] )
            {
                // check for total match
                if ( q.Count == buffer.Length )
                    return;
            }
            else
            {
                // shift the data
                while ( q.Any() && !q.SequenceEqual( buffer.Take( q.Count ) ) )
                {
                    q.RemoveAt( 0 );
                }
            }
        }
    }
