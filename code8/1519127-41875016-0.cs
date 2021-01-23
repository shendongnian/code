    // Add to StateObject
    public const string EOF = "<EOF>";
    public int eofOffset = -1;
    
    // In ReadCallback
    string data = Encoding.ASCII.GetString(state.buffer, 0, bytesRead);
    state.sb.Append(data);
    // Note: this doesn't work for EOF markers with repetitions
    for (int o = 0; o < data.Length; o++)
    {
        if (state.eofOffset != -1 && data[o] != StateObject.EOF[state.eofOffset + 1])
        {
            state.eofOffset = -1;
        }
        if (data[o] == StateObject.EOF[state.eofOffset + 1])
            state.eofOffset++;
            if (state.eofOffset == StateObject.EOF.Length)
            {
                break;
            }
        }
    }
    
    // Replace this:
    //content = state.sb.ToString();
    //if (content.IndexOf("<EOF>") > -1)
    // with this:
    if (state.eofOffset == StateObject.EOF.Length)
    {
        // Here is a good place to turn the StringBuilder into a string
        // Perhaps truncate data to send back up to <EOF>
        // ...
    }
