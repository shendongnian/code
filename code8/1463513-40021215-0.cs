    internal static string GetSafeFileName(string fromString, char usingSafeReplacementChar)
    {
        var invalidChars = System.IO.Path.GetInvalidFileNameChars();
        if (invalidChars.Contains(usingSafeReplacementChar))
            throw new System.ArgumentException(
            string.Format("'{0}' is not a valid safe replacement character.", 
            usingSafeReplacementChar));
        return new string(fromString.Select((inputChar) =>
            invalidChars.Any((invalidChar) =>
            (inputChar == invalidChar)) ? usingSafeReplacementChar : inputChar).ToArray());
    }
