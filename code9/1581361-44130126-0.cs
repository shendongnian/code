        try
        {
            ...
        }
        catch (COMException exception)
        {
            switch (exception.HResult)
            {
                case -2147418113:
                    throw new MissingFolderException("Custom exception");
            }
            Marshal.ThrowExceptionForHR(exception.HResult);
        }
