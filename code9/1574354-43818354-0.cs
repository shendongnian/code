    unsafe delegate void PointerAction(byte* ptr);
    internal static unsafe void GetConstNullTerminated(string text, Encoding encoding,
        PointerAction action)
    {
        int charCount = text.Length;
        fixed (char* chars = text)
        {
            int byteCount = encoding.GetByteCount(chars, charCount);
            byte* bytes = stackalloc byte[byteCount + 1];
            encoding.GetBytes(chars, charCount, bytes, byteCount);
            *(bytes + byteCount) = 0;
            action(bytes);
        }
    }
