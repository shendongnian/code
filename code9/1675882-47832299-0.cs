    [HashAlgorithm.cs]
    /// <summary>Represents the size, in bits, of the computed hash code.</summary>
    protected int HashSizeValue;
    /// <summary>Represents the value of the computed hash code.</summary>
    protected internal byte[] HashValue;
    /// <summary>Represents the state of the hash computation.</summary>
    protected int State;
    [...]
    [HashAlgorithm.cs]
    public byte[] ComputeHash(byte[] buffer)
    {
      if (this.m_bDisposed)
        throw new ObjectDisposedException((string) null);
      if (buffer == null)
        throw new ArgumentNullException(nameof (buffer));
      this.HashCore(buffer, 0, buffer.Length);
      this.HashValue = this.HashFinal();
      byte[] numArray = (byte[]) this.HashValue.Clone();
      this.Initialize();
      return numArray;
    }
