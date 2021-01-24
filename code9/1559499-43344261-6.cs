    /// <summary>
    /// Decrypts a string (ECB)
    /// </summary>
    /// <param name="ct">hHex string of the ciphertext</param>
    /// <returns>Plaintext ascii string</returns>
    public string Decrypt_ECB(string ct)
    {
        return Encoding.ASCII.GetString(Decrypt_ECB(HexToByte(ct))).Replace("\0", "");
    }
