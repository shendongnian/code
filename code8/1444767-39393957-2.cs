    public byte[] Decode(string text) {
        var output = text;
        output = output.Replace('-', '+'); // 62nd char of encoding
        output = output.Replace('_', '/'); // 63rd char of encoding
        switch (output.Length % 4) { // Pad with trailing '='s
            case 0: break; // No pad chars in this case
            case 2: output += "=="; break; // Two pad chars
            case 3: output += "="; break;  // One pad char
            default: throw new FormatException("invalid format", text));
        }
        var converted = Convert.FromBase64String(output); // Standard base64 decoder
        return converted;
    }
