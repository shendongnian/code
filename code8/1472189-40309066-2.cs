    using (FileStream stream = File.OpenRead(file))
    {
        SHA256Managed sha = new SHA256Managed();
        byte[] checksum = sha.ComputeHash(stream);
        return BitConverter.ToString(checksum).Replace("-", String.Empty);
    }
