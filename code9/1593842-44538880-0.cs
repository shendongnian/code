        try
        {
            using (var reader = new StreamReader(filename))
            {
                while (!reader.EndOfStream)
                {
                    { your split implementation }
                }
            }
        }
        // now you dont need to close a stream because
        // using statement will handle it for you
        catch // appropriate exception handling
        {
        }
