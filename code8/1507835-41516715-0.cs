        private void SetLengthCore(long value)
        {
            Contract.Assert(value >= 0, "value >= 0");
            long origPos = _pos;
 
            if (_exposedHandle)
                VerifyOSHandlePosition();
            if (_pos != value)
                SeekCore(value, SeekOrigin.Begin);
            if (!Win32Native.SetEndOfFile(_handle)) {
                int hr = Marshal.GetLastWin32Error();
                if (hr==__Error.ERROR_INVALID_PARAMETER)
                    throw new ArgumentOutOfRangeException("value", Environment.GetResourceString("ArgumentOutOfRange_FileLengthTooBig"));
                __Error.WinIOError(hr, String.Empty);
            }
            // Return file pointer to where it was before setting length
            if (origPos != value) {
                if (origPos < value)
                    SeekCore(origPos, SeekOrigin.Begin);
                else
                    SeekCore(0, SeekOrigin.End);
            }
        }
